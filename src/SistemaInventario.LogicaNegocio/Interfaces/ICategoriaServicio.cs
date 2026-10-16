using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio.Genericos;

namespace SistemaInventario.LogicaNegocio.Interfaces
{
    public interface ICategoriaServicio
    {
        /// <summary>Categorías activas (sin cargar las imágenes, para que el listado sea liviano).</summary>
        Resultado<List<Categoria>> ObtenerActivas();
        Resultado<List<Categoria>> ObtenerEliminadas();
        /// <summary>Una categoría con sus fotos cargadas (para el formulario de edición).</summary>
        Resultado<Categoria> ObtenerPorId(int id);
        /// <summary>Crea la categoría y sus fotos (categoria.Fotos). Devuelve el Id nuevo.</summary>
        Resultado<int> Crear(Categoria categoria);
        /// <summary>Actualiza la categoría y sincroniza sus fotos con categoria.Fotos.</summary>
        Resultado<bool> Actualizar(Categoria categoria);
        Resultado<bool> Eliminar(int id);
        Resultado<bool> Restaurar(int id);
        /// <summary>Filtro en memoria para el cuadro de búsqueda en tiempo real.</summary>
        IEnumerable<Categoria> Filtrar(IEnumerable<Categoria> categorias, string texto);
    }
}