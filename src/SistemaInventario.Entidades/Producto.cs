namespace SistemaInventario.Entidades
{
    public class Producto : EntidadBase
    {
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int CategoriaId { get; set; }
        public int SuplidorId { get; set; }
    }
}