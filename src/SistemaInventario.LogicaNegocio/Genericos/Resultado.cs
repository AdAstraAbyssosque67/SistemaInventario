using SistemaInventario.LogicaNegocio.Validaciones;

namespace SistemaInventario.LogicaNegocio.Genericos
{
    // Resultado de una operación de negocio: éxito con valor, o fallo con mensaje y errores por campo.
    public class Resultado<T>
    {
        private static readonly IReadOnlyDictionary<string, string> SinErrores =
            new Dictionary<string, string>();

        private Resultado(bool exito, T? valor, string mensaje, IReadOnlyDictionary<string, string> errores)
        {
            Exito = exito;
            Valor = valor;
            Mensaje = mensaje;
            Errores = errores;
        }

        public bool Exito { get; }
        public T? Valor { get; }
        // Mensaje general de error (vacío si hubo éxito).
        public string Mensaje { get; }
        // Errores por campo: la clave es el nombre de la propiedad (para ErrorProvider).
        public IReadOnlyDictionary<string, string> Errores { get; }

        public static Resultado<T> Ok(T valor) => new(true, valor, string.Empty, SinErrores);

        public static Resultado<T> Falla(string mensaje) => new(false, default, mensaje, SinErrores);

        public static Resultado<T> FallaValidacion(ResultadoValidacion validacion) =>
            new(false, default, "Corrija los campos marcados.", validacion.Errores);
    }
}