namespace SistemaInventario.LogicaNegocio.Validaciones
{
    // Acumula los errores de validación por campo.
    public class ResultadoValidacion
    {
        private readonly Dictionary<string, string> _errores = new();

        public bool EsValido => _errores.Count == 0;
        public IReadOnlyDictionary<string, string> Errores => _errores;

        // Agrega un error al campo (si el campo ya tiene uno, conserva el primero).
        public void Agregar(string campo, string mensaje) => _errores.TryAdd(campo, mensaje);
    }
}