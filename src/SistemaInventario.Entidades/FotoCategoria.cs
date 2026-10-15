namespace SistemaInventario.Entidades
{
    public class FotoCategoria
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public string NombreArchivo { get; set; } = string.Empty;
        public byte[] Imagen { get; set; } = Array.Empty<byte>();
        public DateTime FechaCreacion { get; set; }
    }
}