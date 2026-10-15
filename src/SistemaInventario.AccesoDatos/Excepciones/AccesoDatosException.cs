namespace SistemaInventario.AccesoDatos.Excepciones
{
    /// <summary>Excepción de la capa de datos; oculta SqlException a las capas superiores.</summary>
    public class AccesoDatosException : Exception
    {
        public AccesoDatosException(string mensaje, Exception? interna = null)
            : base(mensaje, interna) { }
    }
}