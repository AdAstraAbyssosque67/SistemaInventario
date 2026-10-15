using Microsoft.Data.SqlClient;
using SistemaInventario.AccesoDatos.Interfaces;
using SistemaInventario.Entidades;

namespace SistemaInventario.AccesoDatos.Repositorios
{
    public class SuplidorRepositorio : RepositorioBase<Suplidor>, ISuplidorRepositorio
    {
        protected override string NombreTabla => "dbo.Suplidores";
        protected override string SqlSelect =>
            "SELECT Id, NombreEmpresa, NombreContacto, Telefono, Email, SitioWeb, Activo, " +
            "FechaCreacion, FechaModificacion FROM dbo.Suplidores";
        protected override string SqlInsert =>
            "INSERT INTO dbo.Suplidores (NombreEmpresa, NombreContacto, Telefono, Email, SitioWeb, Activo) " +
            "VALUES (@NombreEmpresa, @NombreContacto, @Telefono, @Email, @SitioWeb, 1); " +
            "SELECT CAST(SCOPE_IDENTITY() AS INT);";
        protected override string SqlUpdate =>
            "UPDATE dbo.Suplidores SET NombreEmpresa = @NombreEmpresa, NombreContacto = @NombreContacto, " +
            "Telefono = @Telefono, Email = @Email, SitioWeb = @SitioWeb, " +
            "FechaModificacion = SYSDATETIME() WHERE Id = @Id";

        protected override Suplidor Mapear(SqlDataReader r) => new()
        {
            Id = r.GetInt32(r.GetOrdinal("Id")),
            NombreEmpresa = r.GetString(r.GetOrdinal("NombreEmpresa")),
            NombreContacto = r.GetString(r.GetOrdinal("NombreContacto")),
            Telefono = r.GetString(r.GetOrdinal("Telefono")),
            Email = r.GetString(r.GetOrdinal("Email")),
            SitioWeb = r.IsDBNull(r.GetOrdinal("SitioWeb")) ? null : r.GetString(r.GetOrdinal("SitioWeb")),
            Activo = r.GetBoolean(r.GetOrdinal("Activo")),
            FechaCreacion = r.GetDateTime(r.GetOrdinal("FechaCreacion")),
            FechaModificacion = r.IsDBNull(r.GetOrdinal("FechaModificacion"))
                ? null : r.GetDateTime(r.GetOrdinal("FechaModificacion"))
        };

        protected override void AsignarParametros(SqlCommand cmd, Suplidor s)
        {
            cmd.Parameters.AddWithValue("@NombreEmpresa", s.NombreEmpresa);
            cmd.Parameters.AddWithValue("@NombreContacto", s.NombreContacto);
            cmd.Parameters.AddWithValue("@Telefono", s.Telefono);
            cmd.Parameters.AddWithValue("@Email", s.Email);
            cmd.Parameters.AddWithValue("@SitioWeb", (object?)s.SitioWeb ?? DBNull.Value);
        }

        public bool ExisteNombreEmpresa(string nombre, int? excluirId = null) =>
            EjecutarEscalar<int>(
                "SELECT COUNT(1) FROM dbo.Suplidores WHERE NombreEmpresa = @Nombre AND Activo = 1 AND Id <> @Excluir",
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Excluir", excluirId ?? 0);
                }) > 0;

        public bool TieneProductosActivos(int suplidorId) =>
            EjecutarEscalar<int>(
                "SELECT COUNT(1) FROM dbo.Productos WHERE SuplidorId = @Id AND Activo = 1",
                cmd => cmd.Parameters.AddWithValue("@Id", suplidorId)) > 0;
    }
}
