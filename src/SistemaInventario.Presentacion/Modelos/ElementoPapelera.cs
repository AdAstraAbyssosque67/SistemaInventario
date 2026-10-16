namespace SistemaInventario.Presentacion.Modelos
{
    // Fila de la papelera: sirve para productos, categorías y suplidores eliminados.
    public record ElementoPapelera(int Id, string Nombre, string Detalle, DateTime? Eliminado);
}