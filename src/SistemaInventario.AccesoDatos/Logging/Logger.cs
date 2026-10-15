namespace SistemaInventario.AccesoDatos.Logging
{
    // Escribe errores en el archivo errores.log junto al ejecutable.
    public static class Logger
    {
        private static readonly object _candado = new();
        private static readonly string _ruta = Path.Combine(AppContext.BaseDirectory, "errores.log");

        // Registra una excepción con fecha, contexto y detalle.
        public static void Error(string contexto, Exception ex)
        {
            try
            {
                lock (_candado)
                {
                    File.AppendAllText(_ruta,
                        $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {contexto}{Environment.NewLine}" +
                        $"{ex.GetType().Name}: {ex.Message}{Environment.NewLine}{ex.StackTrace}" +
                        $"{Environment.NewLine}{new string('-', 60)}{Environment.NewLine}");
                }
            }
            catch { /* el logger nunca debe tumbar la aplicación */ }
        }
    }
}