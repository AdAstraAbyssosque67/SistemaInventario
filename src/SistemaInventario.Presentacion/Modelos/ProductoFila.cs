namespace SistemaInventario.Presentacion.Modelos
{
    /// <summary>Fila del listado de productos, con los nombres de categoría y suplidor ya resueltos.</summary>
    public record ProductoFila(int Id, string Nombre, string Categoria, string Suplidor,
                               decimal Precio, DateTime FechaCreacion);
}