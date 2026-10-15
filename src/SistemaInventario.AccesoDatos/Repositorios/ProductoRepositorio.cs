using Microsoft.Data.SqlClient;
using SistemaInventario.AccesoDatos.Interfaces;
using SistemaInventario.Entidades;

namespace SistemaInventario.AccesoDatos.Repositorios
{
    public class ProductoRepositorio : RepositorioBase<Producto>, IProductoRepositorio
    {
        protected override string NombreTabla => "dbo.Productos";
        protected override string SqlSelect =>
            "SELECT Id, Nombre, Precio, CategoriaId, SuplidorId, Activo, " +
            "FechaCreacion, FechaModificacion FROM dbo.Productos";
        protected override string SqlInsert =>
            "INSERT INTO dbo.Productos (Nombre, Precio, CategoriaId, SuplidorId, Activo) " +
            "VALUES (@Nombre, @Precio, @CategoriaId, @SuplidorId, 1); " +
            "SELECT CAST(SCOPE_IDENTITY() AS INT);";
        protected override string SqlUpdate =>
            "UPDATE dbo.Productos SET Nombre = @Nombre, Precio = @Precio, CategoriaId = @CategoriaId, " +
            "SuplidorId = @SuplidorId, FechaModificacion = SYSDATETIME() WHERE Id = @Id";

        protected override Producto Mapear(SqlDataReader r) => new()
        {
            Id = r.GetInt32(r.GetOrdinal("Id")),
            Nombre = r.GetString(r.GetOrdinal("Nombre")),
            Precio = r.GetDecimal(r.GetOrdinal("Precio")),
            CategoriaId = r.GetInt32(r.GetOrdinal("CategoriaId")),
            SuplidorId = r.GetInt32(r.GetOrdinal("SuplidorId")),
            Activo = r.GetBoolean(r.GetOrdinal("Activo")),
            FechaCreacion = r.GetDateTime(r.GetOrdinal("FechaCreacion")),
            FechaModificacion = r.IsDBNull(r.GetOrdinal("FechaModificacion"))
                ? null : r.GetDateTime(r.GetOrdinal("FechaModificacion"))
        };

        protected override void AsignarParametros(SqlCommand cmd, Producto p)
        {
            cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
            cmd.Parameters.Add("@Precio", System.Data.SqlDbType.Decimal).Value = p.Precio;
            cmd.Parameters["@Precio"].Precision = 18;
            cmd.Parameters["@Precio"].Scale = 2;
            cmd.Parameters.AddWithValue("@CategoriaId", p.CategoriaId);
            cmd.Parameters.AddWithValue("@SuplidorId", p.SuplidorId);
        }

        public IEnumerable<Producto> ObtenerPorCategoria(int categoriaId) =>
            EjecutarLectura($"{SqlSelect} WHERE CategoriaId = @Id AND Activo = 1",
                c => c.Parameters.AddWithValue("@Id", categoriaId), Mapear);

        public IEnumerable<Producto> ObtenerPorSuplidor(int suplidorId) =>
            EjecutarLectura($"{SqlSelect} WHERE SuplidorId = @Id AND Activo = 1",
                c => c.Parameters.AddWithValue("@Id", suplidorId), Mapear);
    }
}