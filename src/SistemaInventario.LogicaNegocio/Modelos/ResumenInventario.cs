namespace SistemaInventario.LogicaNegocio.Modelos
{
    // Cifras generales del inventario para el panel de inicio.
    public record ResumenInventario(int Productos, int Categorias, int Suplidores,
                                    decimal PrecioPromedio, int EnPapelera);
}