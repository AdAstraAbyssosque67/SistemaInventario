namespace SistemaInventario.Presentacion.Modelos
{
    /// <summary>Fila de la papelera: sirve para productos, categorías y suplidores eliminados.</summary>
    public record ElementoPapelera(int Id, string Nombre, string Detalle, DateTime? Eliminado);
}