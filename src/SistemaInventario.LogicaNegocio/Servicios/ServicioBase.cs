using SistemaInventario.AccesoDatos.Excepciones;
using SistemaInventario.AccesoDatos.Logging;
using SistemaInventario.LogicaNegocio.Genericos;

namespace SistemaInventario.LogicaNegocio.Servicios
{
    // Base de los servicios: convierte las excepciones de datos en Resultado&lt;T&gt;.</summary>
    public abstract class ServicioBase
    {
        protected Resultado<T> Ejecutar<T>(Func<Resultado<T>> operacion)
        {
            try
            {
                return operacion();
            }
            catch (AccesoDatosException ex)
            {
                return Resultado<T>.Falla(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Error(GetType().Name, ex);
                return Resultado<T>.Falla("Ocurrió un error inesperado. Revise errores.log.");
            }
        }
    }
}