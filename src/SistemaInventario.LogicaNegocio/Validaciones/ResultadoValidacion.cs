namespace SistemaInventario.LogicaNegocio.Validaciones
{
    /// <summary>Acumula los errores de validación por campo.</summary>
    public class ResultadoValidacion
    {
        private readonly Dictionary<string, string> _errores = new();

        public bool EsValido => _errores.Count == 0;
        public IReadOnlyDictionary<string, string> Errores => _errores;

        /// <summary>Agrega un error al campo (si el campo ya tiene uno, conserva el primero).</summary>
        public void Agregar(string campo, string mensaje) => _errores.TryAdd(campo, mensaje);
    }
}