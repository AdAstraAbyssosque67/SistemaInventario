using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio.Genericos;

namespace SistemaInventario.LogicaNegocio.Interfaces
{
    public interface IProductoServicio
    {
        Resultado<List<Producto>> ObtenerActivos();
        Resultado<List<Producto>> ObtenerEliminados();
        Resultado<Producto> ObtenerPorId(int id);
        Resultado<int> Crear(Producto producto);
        Resultado<bool> Actualizar(Producto producto);
        Resultado<bool> Eliminar(int id);
        Resultado<bool> Restaurar(int id);

        // Filtro en memoria: texto en el nombre, categoría, suplidor y rango de precios.
        // Cualquier parámetro nulo o vacío se ignora.
        IEnumerable<Producto> Filtrar(IEnumerable<Producto> productos, string texto,
            int? categoriaId, int? suplidorId, decimal? precioMinimo, decimal? precioMaximo);
    }
}