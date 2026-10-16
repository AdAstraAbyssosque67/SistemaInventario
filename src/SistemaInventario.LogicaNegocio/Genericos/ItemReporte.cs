namespace SistemaInventario.LogicaNegocio.Genericos
{
    // Fila de un reporte: una etiqueta y un valor de cualquier tipo (conteo, promedio, etc.).</summary>
    public record ItemReporte<TValor>(string Etiqueta, TValor Valor);
}