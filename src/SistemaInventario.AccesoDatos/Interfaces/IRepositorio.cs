using SistemaInventario.Entidades;

namespace SistemaInventario.AccesoDatos.Interfaces
{
    // Operaciones CRUD genéricas con borrado lógico.
    public interface IRepositorio<T> where T : EntidadBase
    {
        T? ObtenerPorId(int id);
        IEnumerable<T> ObtenerActivos();
        IEnumerable<T> ObtenerEliminados();
        int Agregar(T entidad);          // devuelve el Id generado
        void Actualizar(T entidad);
        void Eliminar(int id);           // borrado lógico (Activo = 0)
        void Restaurar(int id);          // Activo = 1
    }
}