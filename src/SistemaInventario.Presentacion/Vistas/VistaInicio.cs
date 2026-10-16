using FontAwesome.Sharp;
using LiveChartsCore.SkiaSharpView.WinForms;
using SistemaInventario.LogicaNegocio;
using SistemaInventario.Presentacion.Controles;
using SistemaInventario.Presentacion.Estilos;

namespace SistemaInventario.Presentacion.Vistas
{
    // Panel de inicio: indicadores generales y gráficos del inventario.
    public class VistaInicio : UserControl
    {
        private readonly FabricaServicios _fabrica;

        private readonly TarjetaKpi _kpiProductos = new("Productos", IconChar.Boxes);
        private readonly TarjetaKpi _kpiCategorias = new("Categorías", IconChar.Tags);
        private readonly TarjetaKpi _kpiSuplidores = new("Suplidores", IconChar.Truck);
        private readonly TarjetaKpi _kpiPrecio = new("Precio promedio", IconChar.DollarSign);
        private readonly TarjetaKpi _kpiPapelera = new("En papelera", IconChar.Trash);

        private readonly PieChart _graficoCategorias = new() { BackColor = Tema.Superficie };
        private readonly CartesianChart _graficoSuplidores = new() { BackColor = Tema.Superficie };
        private readonly CartesianChart _graficoPrecios = new() { BackColor = Tema.Superficie };

        public VistaInicio(FabricaServicios fabrica)
        {
            _fabrica = fabrica;
            Construir();
            CargarDatos();
        }

        private void Construir()
        {
            Dock = DockStyle.Fill;
            BackColor = Tema.Fondo;
            Padding = new Padding(18);

            // Fila de indicadores
            var kpis = new TableLayoutPanel { Dock = DockStyle.Top, Height = 112, ColumnCount = 5, RowCount = 1 };
            for (int i = 0; i < 5; i++) kpis.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            kpis.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            kpis.Controls.AddRange(new Control[]
                { _kpiProductos, _kpiCategorias, _kpiSuplidores, _kpiPrecio, _kpiPapelera });

            // Rejilla de gráficos: dos arriba y uno que ocupa todo el ancho abajo
            var rejilla = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 2 };
            rejilla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            rejilla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            rejilla.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            rejilla.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            rejilla.Controls.Add(new Tarjeta("Productos por categoría", _graficoCategorias), 0, 0);
            rejilla.Controls.Add(new Tarjeta("Top 5 suplidores (cantidad de productos)", _graficoSuplidores), 1, 0);
            var tarjetaPrecios = new Tarjeta("Precio promedio por categoría (RD$)", _graficoPrecios);
            rejilla.Controls.Add(tarjetaPrecios, 0, 1);
            rejilla.SetColumnSpan(tarjetaPrecios, 2);

            Controls.Add(rejilla);   // primero el que llena
            Controls.Add(kpis);
        }

        private void CargarDatos()
        {
            var resumen = _fabrica.Reportes.ObtenerResumen();
            var porCategoria = _fabrica.Reportes.ProductosPorCategoria();
            var topSuplidores = _fabrica.Reportes.TopSuplidores(5);
            var promedios = _fabrica.Reportes.PromedioPrecioPorCategoria();

            if (Dialogos.HayError(resumen) || Dialogos.HayError(porCategoria) ||
                Dialogos.HayError(topSuplidores) || Dialogos.HayError(promedios))
                return;

            var datos = resumen.Valor!;
            _kpiProductos.Valor = datos.Productos.ToString("N0");
            _kpiCategorias.Valor = datos.Categorias.ToString("N0");
            _kpiSuplidores.Valor = datos.Suplidores.ToString("N0");
            _kpiPrecio.Valor = $"RD$ {datos.PrecioPromedio:N2}";
            _kpiPapelera.Valor = datos.EnPapelera.ToString("N0");

            Graficos.Dona(_graficoCategorias, porCategoria.Valor!);
            Graficos.Columnas(_graficoSuplidores, topSuplidores.Valor!, "Productos");
            Graficos.Columnas(_graficoPrecios, promedios.Valor!, "Precio promedio");
        }
    }
}