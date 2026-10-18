using SistemaInventario.LogicaNegocio;
using SistemaInventario.Presentacion.Estilos;

namespace SistemaInventario.Presentacion.Vistas
{
    // Panel de inicio: indicadores generales y gráficos del inventario.
    public partial class VistaInicio : UserControl
    {
        private readonly FabricaServicios _fabrica;

        public VistaInicio(FabricaServicios fabrica)
        {
            _fabrica = fabrica;
            InitializeComponent();
            CargarDatos();
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
            kpiProductos.Valor = datos.Productos.ToString("N0");
            kpiCategorias.Valor = datos.Categorias.ToString("N0");
            kpiSuplidores.Valor = datos.Suplidores.ToString("N0");
            kpiPrecio.Valor = $"RD$ {datos.PrecioPromedio:N2}";
            kpiPapelera.Valor = datos.EnPapelera.ToString("N0");

            Graficos.Dona(graficoCategorias, porCategoria.Valor!);
            Graficos.Columnas(graficoSuplidores, topSuplidores.Valor!, "Productos");
            Graficos.Columnas(graficoPrecios, promedios.Valor!, "Precio promedio");
        }
    }
}
