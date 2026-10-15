using System.Data;
using Microsoft.Data.SqlClient;
using SistemaInventario.AccesoDatos.Interfaces;
using SistemaInventario.Entidades;

namespace SistemaInventario.AccesoDatos.Repositorios
{
    public class CategoriaRepositorio : RepositorioBase<Categoria>, ICategoriaRepositorio
    {
        protected override string NombreTabla => "dbo.Categorias";
        protected override string SqlSelect =>
            "SELECT Id, Nombre, Descripcion, Activo, FechaCreacion, FechaModificacion FROM dbo.Categorias";
        protected override string SqlInsert =>
            "INSERT INTO dbo.Categorias (Nombre, Descripcion, Activo) VALUES (@Nombre, @Descripcion, 1); " +
            "SELECT CAST(SCOPE_IDENTITY() AS INT);";
        protected override string SqlUpdate =>
            "UPDATE dbo.Categorias SET Nombre = @Nombre, Descripcion = @Descripcion, " +
            "FechaModificacion = SYSDATETIME() WHERE Id = @Id";

        protected override Categoria Mapear(SqlDataReader r) => new()
        {
            Id = r.GetInt32(r.GetOrdinal("Id")),
            Nombre = r.GetString(r.GetOrdinal("Nombre")),
            Descripcion = r.GetString(r.GetOrdinal("Descripcion")),
            Activo = r.GetBoolean(r.GetOrdinal("Activo")),
            FechaCreacion = r.GetDateTime(r.GetOrdinal("FechaCreacion")),
            FechaModificacion = r.IsDBNull(r.GetOrdinal("FechaModificacion"))
                ? null : r.GetDateTime(r.GetOrdinal("FechaModificacion"))
        };

        protected override void AsignarParametros(SqlCommand cmd, Categoria c)
        {
            cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", c.Descripcion);
        }

        public bool ExisteNombre(string nombre, int? excluirId = null) =>
            EjecutarEscalar<int>(
                "SELECT COUNT(1) FROM dbo.Categorias WHERE Nombre = @Nombre AND Activo = 1 AND Id <> @Excluir",
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Excluir", excluirId ?? 0);
                }) > 0;

        public bool TieneProductosActivos(int categoriaId) =>
            EjecutarEscalar<int>(
                "SELECT COUNT(1) FROM dbo.Productos WHERE CategoriaId = @Id AND Activo = 1",
                cmd => cmd.Parameters.AddWithValue("@Id", categoriaId)) > 0;

        public IEnumerable<FotoCategoria> ObtenerFotos(int categoriaId) =>
            EjecutarLectura(
                "SELECT Id, CategoriaId, NombreArchivo, Imagen, FechaCreacion " +
                "FROM dbo.FotosCategoria WHERE CategoriaId = @Id ORDER BY Id",
                c => c.Parameters.AddWithValue("@Id", categoriaId),
                r => new FotoCategoria
                {
                    Id = r.GetInt32(r.GetOrdinal("Id")),
                    CategoriaId = r.GetInt32(r.GetOrdinal("CategoriaId")),
                    NombreArchivo = r.GetString(r.GetOrdinal("NombreArchivo")),
                    Imagen = r.GetFieldValue<byte[]>(r.GetOrdinal("Imagen")),
                    FechaCreacion = r.GetDateTime(r.GetOrdinal("FechaCreacion"))
                });

        public int ContarFotos(int categoriaId) =>
            EjecutarEscalar<int>(
                "SELECT COUNT(1) FROM dbo.FotosCategoria WHERE CategoriaId = @Id",
                c => c.Parameters.AddWithValue("@Id", categoriaId));

        public int AgregarFoto(FotoCategoria foto) =>
            EjecutarEscalar<int>(
                "INSERT INTO dbo.FotosCategoria (CategoriaId, NombreArchivo, Imagen) " +
                "VALUES (@CategoriaId, @NombreArchivo, @Imagen); SELECT CAST(SCOPE_IDENTITY() AS INT);",
                c =>
                {
                    c.Parameters.AddWithValue("@CategoriaId", foto.CategoriaId);
                    c.Parameters.AddWithValue("@NombreArchivo", foto.NombreArchivo);
                    c.Parameters.Add("@Imagen", SqlDbType.VarBinary, -1).Value = foto.Imagen;
                });

        public void EliminarFoto(int fotoId) =>
            EjecutarNoQuery("DELETE FROM dbo.FotosCategoria WHERE Id = @Id",
                c => c.Parameters.AddWithValue("@Id", fotoId));
    }
}