using SistemaInventario.Entidades;

namespace SistemaInventario.AccesoDatos.Interfaces
{
    public interface ICategoriaRepositorio : IRepositorio<Categoria>
    {
        bool ExisteNombre(string nombre, int? excluirId = null);
        bool TieneProductosActivos(int categoriaId);
        IEnumerable<FotoCategoria> ObtenerFotos(int categoriaId);
        int ContarFotos(int categoriaId);
        int AgregarFoto(FotoCategoria foto);
        void EliminarFoto(int fotoId);
    }
}