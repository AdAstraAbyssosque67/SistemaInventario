using SistemaInventario.AccesoDatos.Interfaces;
using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio.Genericos;
using SistemaInventario.LogicaNegocio.Interfaces;
using SistemaInventario.LogicaNegocio.Validaciones;

namespace SistemaInventario.LogicaNegocio.Servicios
{
    public class ProductoServicio : ServicioBase, IProductoServicio
    {
        private readonly IProductoRepositorio _productos;
        private readonly ICategoriaRepositorio _categorias;
        private readonly ISuplidorRepositorio _suplidores;

        // Recibe los repositorios por constructor (inyección de dependencias).</summary>
        public ProductoServicio(IProductoRepositorio productos,
                                ICategoriaRepositorio categorias,
                                ISuplidorRepositorio suplidores)
        {
            _productos = productos;
            _categorias = categorias;
            _suplidores = suplidores;
        }

        public Resultado<List<Producto>> ObtenerActivos() =>
            Ejecutar(() => Resultado<List<Producto>>.Ok(_productos.ObtenerActivos().ToList()));

        public Resultado<List<Producto>> ObtenerEliminados() =>
            Ejecutar(() => Resultado<List<Producto>>.Ok(_productos.ObtenerEliminados().ToList()));

        public Resultado<Producto> ObtenerPorId(int id) =>
            Ejecutar(() =>
            {
                var producto = _productos.ObtenerPorId(id);
                return producto is null
                    ? Resultado<Producto>.Falla("El producto no existe.")
                    : Resultado<Producto>.Ok(producto);
            });

        public Resultado<int> Crear(Producto producto)
        {
            Normalizar(producto);
            var validacion = Validador.ValidarProducto(producto);
            if (!validacion.EsValido) return Resultado<int>.FallaValidacion(validacion);

            return Ejecutar(() =>
            {
                var relaciones = VerificarRelaciones(producto);
                if (!relaciones.EsValido) return Resultado<int>.FallaValidacion(relaciones);

                return Resultado<int>.Ok(_productos.Agregar(producto));
            });
        }

        public Resultado<bool> Actualizar(Producto producto)
        {
            Normalizar(producto);
            var validacion = Validador.ValidarProducto(producto);
            if (!validacion.EsValido) return Resultado<bool>.FallaValidacion(validacion);

            return Ejecutar(() =>
            {
                var existente = _productos.ObtenerPorId(producto.Id);
                if (existente is null || !existente.Activo)
                    return Resultado<bool>.Falla("El producto no existe o está en la papelera.");

                var relaciones = VerificarRelaciones(producto);
                if (!relaciones.EsValido) return Resultado<bool>.FallaValidacion(relaciones);

                _productos.Actualizar(producto);
                return Resultado<bool>.Ok(true);
            });
        }

        public Resultado<bool> Eliminar(int id) =>
            Ejecutar(() =>
            {
                _productos.Eliminar(id);
                return Resultado<bool>.Ok(true);
            });

        public Resultado<bool> Restaurar(int id) =>
            Ejecutar(() =>
            {
                var producto = _productos.ObtenerPorId(id);
                if (producto is null) return Resultado<bool>.Falla("El producto no existe.");

                var categoria = _categorias.ObtenerPorId(producto.CategoriaId);
                if (categoria is null || !categoria.Activo)
                    return Resultado<bool>.Falla("No se puede restaurar: su categoría está en la papelera. Restáurela primero.");

                var suplidor = _suplidores.ObtenerPorId(producto.SuplidorId);
                if (suplidor is null || !suplidor.Activo)
                    return Resultado<bool>.Falla("No se puede restaurar: su suplidor está en la papelera. Restáurelo primero.");

                _productos.Restaurar(id);
                return Resultado<bool>.Ok(true);
            });

        // LINQ: filtros combinables por nombre, categoría, suplidor y rango de precios.</summary>
        public IEnumerable<Producto> Filtrar(IEnumerable<Producto> productos, string texto,
            int? categoriaId, int? suplidorId, decimal? precioMinimo, decimal? precioMaximo)
        {
            var consulta = productos;

            if (!string.IsNullOrWhiteSpace(texto))
            {
                string busqueda = texto.Trim();
                consulta = consulta.Where(p => p.Nombre.Contains(busqueda, StringComparison.OrdinalIgnoreCase));
            }
            if (categoriaId.HasValue)
                consulta = consulta.Where(p => p.CategoriaId == categoriaId.Value);
            if (suplidorId.HasValue)
                consulta = consulta.Where(p => p.SuplidorId == suplidorId.Value);
            if (precioMinimo.HasValue)
                consulta = consulta.Where(p => p.Precio >= precioMinimo.Value);
            if (precioMaximo.HasValue)
                consulta = consulta.Where(p => p.Precio <= precioMaximo.Value);

            return consulta.OrderBy(p => p.Nombre);
        }

        // La categoría y el suplidor deben existir y estar activos.</summary>
        private ResultadoValidacion VerificarRelaciones(Producto producto)
        {
            var v = new ResultadoValidacion();

            var categoria = _categorias.ObtenerPorId(producto.CategoriaId);
            if (categoria is null || !categoria.Activo)
                v.Agregar(nameof(Producto.CategoriaId), "La categoría debe existir y estar activa.");

            var suplidor = _suplidores.ObtenerPorId(producto.SuplidorId);
            if (suplidor is null || !suplidor.Activo)
                v.Agregar(nameof(Producto.SuplidorId), "El suplidor debe existir y estar activo.");

            return v;
        }

        private static void Normalizar(Producto producto) =>
            producto.Nombre = producto.Nombre?.Trim() ?? string.Empty;
    }
}