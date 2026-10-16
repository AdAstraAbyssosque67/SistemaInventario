using LiveChartsCore;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using SistemaInventario.LogicaNegocio.Genericos;
using SkiaSharp;

namespace SistemaInventario.Presentacion.Estilos
{
    // Construye gráficos (barras y dona) con los colores de la aplicación.
    public static class Graficos
    {
        private static readonly SKColor[] Paleta =
        {
            new(0, 177, 157), new(255, 176, 80), new(242, 109, 80),
            new(96, 125, 139), new(129, 230, 217), new(171, 221, 164), new(0, 120, 107)
        };

        private static SKColor ASkia(Color color) => new(color.R, color.G, color.B);

        // Gráfico de barras verticales: una barra por cada ItemReporte.
        public static void Columnas<TValor>(CartesianChart grafico, IEnumerable<ItemReporte<TValor>> items,
                                            string nombreSerie) where TValor : struct, IConvertible
        {
            var lista = items.ToList();
            var textoSuave = new SolidColorPaint(ASkia(Tema.TextoSuave));

            grafico.Series = new ISeries[]
            {
                new ColumnSeries<double>
                {
                    Name = nombreSerie,
                    Values = lista.Select(i => Convert.ToDouble(i.Valor)).ToArray(),
                    Fill = new SolidColorPaint(ASkia(Tema.Primario)),
                    MaxBarWidth = 56,
                    DataLabelsPaint = new SolidColorPaint(ASkia(Tema.Texto)),
                    DataLabelsSize = 12,
                    DataLabelsPosition = DataLabelsPosition.End
                }
            };

            grafico.XAxes = new[]
            {
                new Axis
                {
                    Labels = lista.Select(i => i.Etiqueta).ToArray(),
                    LabelsRotation = 15,
                    TextSize = 12,
                    LabelsPaint = textoSuave
                }
            };

            grafico.YAxes = new[]
            {
                new Axis
                {
                    MinLimit = 0,
                    TextSize = 12,
                    LabelsPaint = textoSuave,
                    SeparatorsPaint = new SolidColorPaint(ASkia(Tema.Borde)) { StrokeThickness = 1 }
                }
            };
        }

        // Gráfico de dona: una porción por cada ItemReporte con valor mayor que cero.
        public static void Dona<TValor>(PieChart grafico, IEnumerable<ItemReporte<TValor>> items)
            where TValor : struct, IConvertible
        {
            grafico.Series = items
                .Where(item => Convert.ToDouble(item.Valor) > 0)
                .Select((item, indice) => (ISeries)new PieSeries<double>
                {
                    Name = item.Etiqueta,
                    Values = new[] { Convert.ToDouble(item.Valor) },
                    InnerRadius = 55,
                    Fill = new SolidColorPaint(Paleta[indice % Paleta.Length])
                })
                .ToArray();

            grafico.LegendPosition = LegendPosition.Right;
        }
    }
}