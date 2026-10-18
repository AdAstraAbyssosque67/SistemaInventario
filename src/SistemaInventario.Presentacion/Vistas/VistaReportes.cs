using SistemaInventario.LogicaNegocio;
using SistemaInventario.LogicaNegocio.Genericos;
using SistemaInventario.Presentacion.Controles;
using SistemaInventario.Presentacion.Estilos;

namespace SistemaInventario.Presentacion.Vistas
{
    // Reportes del inventario: cada uno con su tabla y su gráfico.
    public partial class VistaReportes : UserControl
    {
        private record Reporte(string EncabezadoEtiqueta, string EncabezadoValor, string Formato,
                               Func<Resultado<List<ItemReporte<decimal>>>> Cargar);

        private readonly Dictionary<BotonPestana, Reporte> _reportes;

        public VistaReportes(FabricaServicios fabrica)
        {
            InitializeComponent();

            _reportes = new Dictionary<BotonPestana, Reporte>
            {
                [rbtnPorCategoria] = new("Categoría", "Productos", "N0",
                    () => ADecimal(fabrica.Reportes.ProductosPorCategoria())),
                [rbtnTopSuplidores] = new("Suplidor", "Productos", "N0",
                    () => ADecimal(fabrica.Reportes.TopSuplidores(5))),
                [rbtnPrecioPromedio] = new("Categoría", "Promedio (RD$)", "N2",
                    () => fabrica.Reportes.PromedioPrecioPorCategoria())
            };

            rbtnPorCategoria.Checked = true;   // muestra el primer reporte al abrir
        }

        // Unifica reportes de enteros y decimales en ItemReporte<decimal>.
        private static Resultado<List<ItemReporte<decimal>>> ADecimal<T>(Resultado<List<ItemReporte<T>>> origen)
            where T : struct, IConvertible =>
            origen.Exito
                ? Resultado<List<ItemReporte<decimal>>>.Ok(origen.Valor!
                    .Select(i => new ItemReporte<decimal>(i.Etiqueta, Convert.ToDecimal(i.Valor)))
                    .ToList())
                : Resultado<List<ItemReporte<decimal>>>.Falla(origen.Mensaje);

        private void rbtnReporte_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender is BotonPestana { Checked: true } pestana) Mostrar(_reportes[pestana]);
        }

        private void Mostrar(Reporte reporte)
        {
            var resultado = reporte.Cargar();
            if (Dialogos.HayError(resultado)) return;

            var datos = resultado.Valor!;
            colEtiqueta.HeaderText = reporte.EncabezadoEtiqueta;
            colValor.HeaderText = reporte.EncabezadoValor;
            colValor.DefaultCellStyle.Format = reporte.Formato;
            grid.DataSource = datos;

            Graficos.Columnas(grafico, datos, reporte.EncabezadoValor);
        }
    }
}
