using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio.Genericos;

namespace SistemaInventario.LogicaNegocio.Interfaces
{
    public interface ISuplidorServicio
    {
        Resultado<List<Suplidor>> ObtenerActivos();
        Resultado<List<Suplidor>> ObtenerEliminados();
        Resultado<Suplidor> ObtenerPorId(int id);
        Resultado<int> Crear(Suplidor suplidor);
        Resultado<bool> Actualizar(Suplidor suplidor);
        Resultado<bool> Eliminar(int id);
        Resultado<bool> Restaurar(int id);
        // Filtro en memoria para el cuadro de búsqueda en tiempo real.</summary>
        IEnumerable<Suplidor> Filtrar(IEnumerable<Suplidor> suplidores, string texto);
    }
}