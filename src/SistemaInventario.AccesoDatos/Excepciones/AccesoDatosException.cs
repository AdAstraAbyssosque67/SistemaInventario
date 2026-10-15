namespace SistemaInventario.AccesoDatos.Excepciones
{
    // Excepción de la capa de datos; oculta SqlException a las capas superiores.
    public class AccesoDatosException : Exception
    {
        public AccesoDatosException(string mensaje, Exception? interna = null)
            : base(mensaje, interna) { }
    }
}