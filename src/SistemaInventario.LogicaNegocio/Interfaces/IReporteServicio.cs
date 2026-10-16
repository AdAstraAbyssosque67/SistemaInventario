using SistemaInventario.LogicaNegocio.Genericos;
using SistemaInventario.LogicaNegocio.Modelos;

namespace SistemaInventario.LogicaNegocio.Interfaces
{
    public interface IReporteServicio
    {
        // Cantidad de productos activos por categoría (incluye categorías sin productos).
        Resultado<List<ItemReporte<int>>> ProductosPorCategoria();

        // Los suplidores con más productos activos.
        Resultado<List<ItemReporte<int>>> TopSuplidores(int cantidad = 5);

        // Precio promedio de los productos activos por categoría.
        Resultado<List<ItemReporte<decimal>>> PromedioPrecioPorCategoria();

        // Totales generales: productos, categorías, suplidores, precio promedio y elementos en papelera.
        Resultado<ResumenInventario> ObtenerResumen();
    }
}