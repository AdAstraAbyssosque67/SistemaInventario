using LiveChartsCore.SkiaSharpView.WinForms;
using SistemaInventario.LogicaNegocio;
using SistemaInventario.LogicaNegocio.Genericos;
using SistemaInventario.Presentacion.Controles;
using SistemaInventario.Presentacion.Estilos;

namespace SistemaInventario.Presentacion.Vistas
{
    // Reportes del inventario: cada uno con su tabla y su gráfico.
    public class VistaReportes : UserControl
    {
        private record Reporte(string Texto, string EncabezadoEtiqueta, string EncabezadoValor,
                               string Formato, Func<Resultado<List<ItemReporte<decimal>>>> Cargar);

        private readonly FabricaServicios _fabrica;
        private readonly List<Reporte> _reportes;
        private readonly DataGridView _grid = new();
        private readonly CartesianChart _grafico = new() { BackColor = Tema.Superficie };
        private readonly DataGridViewTextBoxColumn _colEtiqueta =
            Estilo.Columna("", nameof(ItemReporte<decimal>.Etiqueta), 60);
        private readonly DataGridViewTextBoxColumn _colValor =
            Estilo.Columna("", nameof(ItemReporte<decimal>.Valor), 40);

        public VistaReportes(FabricaServicios fabrica)
        {
            _fabrica = fabrica;
            _reportes = new List<Reporte>
            {
                new("Productos por categoría", "Categoría", "Productos", "N0",
                    () => ADecimal(_fabrica.Reportes.ProductosPorCategoria())),
                new("Top 5 suplidores", "Suplidor", "Productos", "N0",
                    () => ADecimal(_fabrica.Reportes.TopSuplidores(5))),
                new("Precio promedio por categoría", "Categoría", "Promedio (RD$)", "N2",
                    () => _fabrica.Reportes.PromedioPrecioPorCategoria())
            };
            Construir();
        }

        // Método genérico: unifica reportes de enteros y decimales en ItemReporte&lt;decimal&gt;.
        private static Resultado<List<ItemReporte<decimal>>> ADecimal<T>(Resultado<List<ItemReporte<T>>> origen)
            where T : struct, IConvertible =>
            origen.Exito
                ? Resultado<List<ItemReporte<decimal>>>.Ok(origen.Valor!
                    .Select(i => new ItemReporte<decimal>(i.Etiqueta, Convert.ToDecimal(i.Valor)))
                    .ToList())
                : Resultado<List<ItemReporte<decimal>>>.Falla(origen.Mensaje);

        private void Construir()
        {
            Dock = DockStyle.Fill;
            BackColor = Tema.Fondo;
            Padding = new Padding(18);

            // Botones tipo pestaña
            var selector = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 54,
                WrapContents = false,
                Padding = new Padding(6, 6, 0, 0)
            };
            foreach (var reporte in _reportes)
            {
                var pestana = Estilo.BotonPestana(reporte.Texto, 230);
                pestana.CheckedChanged += (_, _) => { if (pestana.Checked) Mostrar(reporte); };
                selector.Controls.Add(pestana);
            }

            // Tabla
            Estilo.AplicarTabla(_grid);
            _colValor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _grid.Columns.AddRange(_colEtiqueta, _colValor);

            // Tabla a la izquierda y gráfico a la derecha
            var rejilla = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1 };
            rejilla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38F));
            rejilla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62F));
            rejilla.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rejilla.Controls.Add(new Tarjeta("Datos", _grid), 0, 0);
            rejilla.Controls.Add(new Tarjeta("Gráfico", _grafico), 1, 0);

            Controls.Add(rejilla);
            Controls.Add(selector);

            ((RadioButton)selector.Controls[0]).Checked = true;   // muestra el primer reporte al abrir
        }

        private void Mostrar(Reporte reporte)
        {
            var resultado = reporte.Cargar();
            if (Dialogos.HayError(resultado)) return;

            var datos = resultado.Valor!;
            _colEtiqueta.HeaderText = reporte.EncabezadoEtiqueta;
            _colValor.HeaderText = reporte.EncabezadoValor;
            _colValor.DefaultCellStyle.Format = reporte.Formato;
            _grid.DataSource = datos;

            Graficos.Columnas(_grafico, datos, reporte.EncabezadoValor);
        }
    }
}