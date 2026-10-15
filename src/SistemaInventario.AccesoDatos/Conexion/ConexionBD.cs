using Microsoft.Data.SqlClient;

namespace SistemaInventario.AccesoDatos.Conexion
{
    // Singleton que centraliza la cadena de conexión. Entrega una conexión
    // nueva por operación (ADO.NET ya hace pooling internamente).
    public sealed class ConexionBD
    {
        private static readonly Lazy<ConexionBD> _instancia =
            new(() => new ConexionBD(), LazyThreadSafetyMode.ExecutionAndPublication);

        private string _cadenaConexion =
            "Server=localhost;Database=SistemaInventario;Trusted_Connection=True;TrustServerCertificate=True;";

        private ConexionBD() { }

        // Única instancia de la conexión.
        public static ConexionBD Instancia => _instancia.Value;

        // Cambia la cadena de conexión (por si el servidor no es localhost).
        public void Configurar(string cadenaConexion)
        {
            if (string.IsNullOrWhiteSpace(cadenaConexion))
                throw new ArgumentException("La cadena de conexión no puede estar vacía.", nameof(cadenaConexion));
            _cadenaConexion = cadenaConexion;
        }

        // Crea una conexión nueva (sin abrir). Quien la use debe disponer de ella.
        public SqlConnection CrearConexion() => new SqlConnection(_cadenaConexion);
    }
}