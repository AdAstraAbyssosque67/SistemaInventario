using SistemaInventario.LogicaNegocio.Genericos;

namespace SistemaInventario.LogicaNegocio.Interfaces
{
    public interface IReporteServicio
    {
        // Cantidad de productos activos por categoría (incluye categorías sin productos).</summary>
        Resultado<List<ItemReporte<int>>> ProductosPorCategoria();

        // Los suplidores con más productos activos.</summary>
        Resultado<List<ItemReporte<int>>> TopSuplidores(int cantidad = 5);

        // Precio promedio de los productos activos por categoría.</summary>
        Resultado<List<ItemReporte<decimal>>> PromedioPrecioPorCategoria();
    }
}