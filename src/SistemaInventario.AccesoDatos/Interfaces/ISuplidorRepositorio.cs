using SistemaInventario.Entidades;

namespace SistemaInventario.AccesoDatos.Interfaces
{
    public interface ISuplidorRepositorio : IRepositorio<Suplidor>
    {
        bool ExisteNombreEmpresa(string nombre, int? excluirId = null);
        bool TieneProductosActivos(int suplidorId);
    }
}