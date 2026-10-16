using System.Text.RegularExpressions;
using SistemaInventario.Entidades;

namespace SistemaInventario.LogicaNegocio.Validaciones
{
    /// <summary>Reglas de validación de las entidades.</summary>
    public static class Validador
    {
        public const int MaximoFotos = 5;
        public const int TamanoMaximoFoto = 2 * 1024 * 1024; // 2 MB

        private static readonly Regex RegexEmail =
            new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);
        private static readonly Regex RegexTelefono =
            new(@"^(809|829|849)-\d{3}-\d{4}$", RegexOptions.Compiled);
        private static readonly string[] ExtensionesFoto = { ".jpg", ".jpeg", ".png" };

        /// <summary>Valida una categoría y sus fotos.</summary>
        public static ResultadoValidacion ValidarCategoria(Categoria categoria)
        {
            var r = new ResultadoValidacion();
            ValidarTexto(r, nameof(Categoria.Nombre), "el nombre", categoria.Nombre, 3, 100);
            ValidarTexto(r, nameof(Categoria.Descripcion), "la descripción", categoria.Descripcion, 1, 500);

            if (categoria.Fotos.Count > MaximoFotos)
                r.Agregar(nameof(Categoria.Fotos), $"Máximo {MaximoFotos} fotos por categoría.");

            foreach (var foto in categoria.Fotos)
            {
                string? error = ValidarFoto(foto.NombreArchivo, foto.Imagen);
                if (error != null)
                {
                    r.Agregar(nameof(Categoria.Fotos), error);
                    break;
                }
            }
            return r;
        }

        /// <summary>Valida un suplidor.</summary>
        public static ResultadoValidacion ValidarSuplidor(Suplidor suplidor)
        {
            var r = new ResultadoValidacion();
            ValidarTexto(r, nameof(Suplidor.NombreEmpresa), "el nombre de la empresa", suplidor.NombreEmpresa, 1, 150);
            ValidarTexto(r, nameof(Suplidor.NombreContacto), "el nombre del contacto", suplidor.NombreContacto, 1, 100);

            if (string.IsNullOrWhiteSpace(suplidor.Telefono))
                r.Agregar(nameof(Suplidor.Telefono), "Debe indicar el teléfono.");
            else if (!EsTelefonoValido(suplidor.Telefono))
                r.Agregar(nameof(Suplidor.Telefono), "Formato: 809/829/849-XXX-XXXX.");

            if (string.IsNullOrWhiteSpace(suplidor.Email))
                r.Agregar(nameof(Suplidor.Email), "Debe indicar el correo electrónico.");
            else if (suplidor.Email.Length > 150 || !EsEmailValido(suplidor.Email))
                r.Agregar(nameof(Suplidor.Email), "El correo electrónico no es válido.");

            if (!string.IsNullOrWhiteSpace(suplidor.SitioWeb) &&
                (suplidor.SitioWeb.Length > 300 || !EsUrlValida(suplidor.SitioWeb)))
                r.Agregar(nameof(Suplidor.SitioWeb), "La URL no es válida (ej: https://www.sitio.com).");

            return r;
        }

        /// <summary>Valida un producto (la existencia/actividad de categoría y suplidor se verifica en el servicio).</summary>
        public static ResultadoValidacion ValidarProducto(Producto producto)
        {
            var r = new ResultadoValidacion();
            ValidarTexto(r, nameof(Producto.Nombre), "el nombre del producto", producto.Nombre, 1, 150);

            if (producto.Precio <= 0)
                r.Agregar(nameof(Producto.Precio), "El precio debe ser mayor que 0.");
            else if (decimal.Round(producto.Precio, 2) != producto.Precio)
                r.Agregar(nameof(Producto.Precio), "El precio admite máximo 2 decimales.");

            if (producto.CategoriaId <= 0)
                r.Agregar(nameof(Producto.CategoriaId), "Seleccione una categoría.");
            if (producto.SuplidorId <= 0)
                r.Agregar(nameof(Producto.SuplidorId), "Seleccione un suplidor.");

            return r;
        }

        /// <summary>Valida una foto. Devuelve el mensaje de error o null si es válida.</summary>
        public static string? ValidarFoto(string nombreArchivo, byte[] imagen)
        {
            string extension = Path.GetExtension(nombreArchivo).ToLowerInvariant();
            if (!ExtensionesFoto.Contains(extension))
                return $"'{nombreArchivo}': solo se permiten archivos .jpg, .jpeg o .png.";
            if (imagen.Length == 0)
                return $"'{nombreArchivo}' está vacío.";
            if (imagen.Length > TamanoMaximoFoto)
                return $"'{nombreArchivo}' supera el máximo de 2 MB.";
            return null;
        }

        public static bool EsEmailValido(string email) => RegexEmail.IsMatch(email);

        public static bool EsTelefonoValido(string telefono) => RegexTelefono.IsMatch(telefono);

        public static bool EsUrlValida(string url) =>
            Uri.TryCreate(url, UriKind.Absolute, out var uri) &&
            (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);

        private static void ValidarTexto(ResultadoValidacion r, string campo, string etiqueta,
                                         string valor, int minimo, int maximo)
        {
            string texto = valor?.Trim() ?? string.Empty;
            if (texto.Length == 0) r.Agregar(campo, $"Debe indicar {etiqueta}.");
            else if (texto.Length < minimo) r.Agregar(campo, $"Mínimo {minimo} caracteres.");
            else if (texto.Length > maximo) r.Agregar(campo, $"Máximo {maximo} caracteres.");
        }
    }
}