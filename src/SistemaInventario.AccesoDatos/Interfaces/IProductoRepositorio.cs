using SistemaInventario.Entidades;
namespace SistemaInventario.AccesoDatos.Interfaces
{
    public interface IProductoRepositorio : IRepositorio<Producto>
    {
        IEnumerable<Producto> ObtenerPorCategoria(int categoriaId);
        IEnumerable<Producto> ObtenerPorSuplidor(int suplidorId);
    }
}