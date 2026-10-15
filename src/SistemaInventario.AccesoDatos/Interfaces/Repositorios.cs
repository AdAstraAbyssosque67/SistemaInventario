using Microsoft.Data.SqlClient;
using SistemaInventario.AccesoDatos.Conexion;
using SistemaInventario.AccesoDatos.Excepciones;
using SistemaInventario.AccesoDatos.Interfaces;
using SistemaInventario.AccesoDatos.Logging;
using SistemaInventario.Entidades;

namespace SistemaInventario.AccesoDatos.Repositorios
{
    // Implementación genérica de IRepositorio&lt;T&gt; sobre ADO.NET.
    public abstract class RepositorioBase<T> : IRepositorio<T> where T : EntidadBase
    {
        protected abstract string NombreTabla { get; }
        // SELECT de todas las columnas, sin WHERE.
        protected abstract string SqlSelect { get; }
        // INSERT que termina con SELECT CAST(SCOPE_IDENTITY() AS INT).
        protected abstract string SqlInsert { get; }
        // UPDATE ... WHERE Id = @Id (incluye FechaModificacion = SYSDATETIME()).
        protected abstract string SqlUpdate { get; }

        protected abstract T Mapear(SqlDataReader lector);
        protected abstract void AsignarParametros(SqlCommand cmd, T entidad);

        public T? ObtenerPorId(int id) =>
            EjecutarLectura($"{SqlSelect} WHERE Id = @Id",
                c => c.Parameters.AddWithValue("@Id", id), Mapear).FirstOrDefault();

        public IEnumerable<T> ObtenerActivos() =>
            EjecutarLectura($"{SqlSelect} WHERE Activo = 1 ORDER BY Id", null, Mapear);

        public IEnumerable<T> ObtenerEliminados() =>
            EjecutarLectura($"{SqlSelect} WHERE Activo = 0 ORDER BY Id", null, Mapear);

        public int Agregar(T entidad) =>
            EjecutarEscalar<int>(SqlInsert, c => AsignarParametros(c, entidad));

        public void Actualizar(T entidad) =>
            EjecutarNoQuery(SqlUpdate, c =>
            {
                AsignarParametros(c, entidad);
                c.Parameters.AddWithValue("@Id", entidad.Id);
            });

        public void Eliminar(int id) => CambiarEstado(id, false);
        public void Restaurar(int id) => CambiarEstado(id, true);

        private void CambiarEstado(int id, bool activo) =>
            EjecutarNoQuery(
                $"UPDATE {NombreTabla} SET Activo = @Activo, FechaModificacion = SYSDATETIME() WHERE Id = @Id",
                c =>
                {
                    c.Parameters.AddWithValue("@Activo", activo);
                    c.Parameters.AddWithValue("@Id", id);
                });

        // ---------- Helpers (el método genérico propio adicional) ----------

        // Ejecuta una consulta y mapea cada fila a TResultado.
        protected List<TResultado> EjecutarLectura<TResultado>(
            string sql, Action<SqlCommand>? parametros, Func<SqlDataReader, TResultado> mapear)
        {
            try
            {
                using var conexion = ConexionBD.Instancia.CrearConexion();
                using var cmd = new SqlCommand(sql, conexion);
                parametros?.Invoke(cmd);
                conexion.Open();
                using var lector = cmd.ExecuteReader();
                var lista = new List<TResultado>();
                while (lector.Read()) lista.Add(mapear(lector));
                return lista;
            }
            catch (SqlException ex) { throw Envolver(ex, sql); }
        }

        protected int EjecutarNoQuery(string sql, Action<SqlCommand>? parametros)
        {
            try
            {
                using var conexion = ConexionBD.Instancia.CrearConexion();
                using var cmd = new SqlCommand(sql, conexion);
                parametros?.Invoke(cmd);
                conexion.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) { throw Envolver(ex, sql); }
        }

        protected TResultado EjecutarEscalar<TResultado>(string sql, Action<SqlCommand>? parametros)
        {
            try
            {
                using var conexion = ConexionBD.Instancia.CrearConexion();
                using var cmd = new SqlCommand(sql, conexion);
                parametros?.Invoke(cmd);
                conexion.Open();
                return (TResultado)Convert.ChangeType(cmd.ExecuteScalar()!, typeof(TResultado));
            }
            catch (SqlException ex) { throw Envolver(ex, sql); }
        }

        private AccesoDatosException Envolver(SqlException ex, string sql)
        {
            Logger.Error($"{GetType().Name} - SQL: {sql}", ex);
            string mensaje = ex.Number switch
            {
                2601 or 2627 => "Ya existe un registro con ese valor único.",
                547 => "La operación viola una relación con otros registros.",
                -1 or 53 or 4060 => "No se pudo conectar con la base de datos.",
                _ => "Ocurrió un error al acceder a la base de datos."
            };
            return new AccesoDatosException(mensaje, ex);
        }
    }
}