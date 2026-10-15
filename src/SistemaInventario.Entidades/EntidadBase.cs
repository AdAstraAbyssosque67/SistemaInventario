// EntidadBase.cs
namespace SistemaInventario.Entidades
{
    /// <summary>Clase base de las entidades con borrado lógico y fechas de auditoría.</summary>
    public abstract class EntidadBase
    {
        public int Id { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}

// Categoria.cs
namespace SistemaInventario.Entidades
{
    public class Categoria : EntidadBase
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public List<FotoCategoria> Fotos { get; set; } = new();
    }
}

// FotoCategoria.cs
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

// Suplidor.cs
namespace SistemaInventario.Entidades
{
    public class Suplidor : EntidadBase
    {
        public string NombreEmpresa { get; set; } = string.Empty;
        public string NombreContacto { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? SitioWeb { get; set; }
    }
}

// Producto.cs
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