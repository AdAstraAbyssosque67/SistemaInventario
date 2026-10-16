using SistemaInventario.AccesoDatos.Interfaces;
using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio.Genericos;
using SistemaInventario.LogicaNegocio.Interfaces;
using SistemaInventario.LogicaNegocio.Validaciones;

namespace SistemaInventario.LogicaNegocio.Servicios
{
    public class CategoriaServicio : ServicioBase, ICategoriaServicio
    {
        private readonly ICategoriaRepositorio _repositorio;

        // Recibe el repositorio por constructor (inyección de dependencias).
        public CategoriaServicio(ICategoriaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Resultado<List<Categoria>> ObtenerActivas() =>
            Ejecutar(() => Resultado<List<Categoria>>.Ok(_repositorio.ObtenerActivos().ToList()));

        public Resultado<List<Categoria>> ObtenerEliminadas() =>
            Ejecutar(() => Resultado<List<Categoria>>.Ok(_repositorio.ObtenerEliminados().ToList()));

        public Resultado<Categoria> ObtenerPorId(int id) =>
            Ejecutar(() =>
            {
                var categoria = _repositorio.ObtenerPorId(id);
                if (categoria is null) return Resultado<Categoria>.Falla("La categoría no existe.");
                categoria.Fotos = _repositorio.ObtenerFotos(id).ToList();
                return Resultado<Categoria>.Ok(categoria);
            });

        public Resultado<int> Crear(Categoria categoria)
        {
            Normalizar(categoria);
            var validacion = Validador.ValidarCategoria(categoria);
            if (!validacion.EsValido) return Resultado<int>.FallaValidacion(validacion);

            return Ejecutar(() =>
            {
                if (_repositorio.ExisteNombre(categoria.Nombre))
                    return NombreDuplicado<int>();

                int id = _repositorio.Agregar(categoria);
                foreach (var foto in categoria.Fotos)
                {
                    foto.CategoriaId = id;
                    _repositorio.AgregarFoto(foto);
                }
                return Resultado<int>.Ok(id);
            });
        }

        public Resultado<bool> Actualizar(Categoria categoria)
        {
            Normalizar(categoria);
            var validacion = Validador.ValidarCategoria(categoria);
            if (!validacion.EsValido) return Resultado<bool>.FallaValidacion(validacion);

            return Ejecutar(() =>
            {
                var existente = _repositorio.ObtenerPorId(categoria.Id);
                if (existente is null || !existente.Activo)
                    return Resultado<bool>.Falla("La categoría no existe o está en la papelera.");

                if (_repositorio.ExisteNombre(categoria.Nombre, categoria.Id))
                    return NombreDuplicado<bool>();

                _repositorio.Actualizar(categoria);
                SincronizarFotos(categoria);
                return Resultado<bool>.Ok(true);
            });
        }

        public Resultado<bool> Eliminar(int id) =>
            Ejecutar(() =>
            {
                if (_repositorio.TieneProductosActivos(id))
                    return Resultado<bool>.Falla("No se puede eliminar: la categoría tiene productos activos asociados.");

                _repositorio.Eliminar(id);
                return Resultado<bool>.Ok(true);
            });

        public Resultado<bool> Restaurar(int id) =>
            Ejecutar(() =>
            {
                var categoria = _repositorio.ObtenerPorId(id);
                if (categoria is null) return Resultado<bool>.Falla("La categoría no existe.");

                if (_repositorio.ExisteNombre(categoria.Nombre, categoria.Id))
                    return Resultado<bool>.Falla(
                        $"No se puede restaurar: ya existe una categoría activa llamada '{categoria.Nombre}'.");

                _repositorio.Restaurar(id);
                return Resultado<bool>.Ok(true);
            });

        // LINQ: búsqueda parcial por nombre o descripción, ignorando mayúsculas/minúsculas.
        public IEnumerable<Categoria> Filtrar(IEnumerable<Categoria> categorias, string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return categorias;
            string busqueda = texto.Trim();
            return categorias.Where(c =>
                c.Nombre.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                c.Descripcion.Contains(busqueda, StringComparison.OrdinalIgnoreCase));
        }

        // Compara las fotos de la BD con las de la categoría: borra las que ya no están y agrega las nuevas (Id = 0).
        private void SincronizarFotos(Categoria categoria)
        {
            var idsConservados = categoria.Fotos
                .Where(f => f.Id != 0)
                .Select(f => f.Id)
                .ToHashSet();

            foreach (var foto in _repositorio.ObtenerFotos(categoria.Id).Where(f => !idsConservados.Contains(f.Id)))
                _repositorio.EliminarFoto(foto.Id);

            foreach (var foto in categoria.Fotos.Where(f => f.Id == 0))
            {
                foto.CategoriaId = categoria.Id;
                _repositorio.AgregarFoto(foto);
            }
        }

        private static void Normalizar(Categoria categoria)
        {
            categoria.Nombre = categoria.Nombre?.Trim() ?? string.Empty;
            categoria.Descripcion = categoria.Descripcion?.Trim() ?? string.Empty;
        }

        private static Resultado<T> NombreDuplicado<T>()
        {
            var v = new ResultadoValidacion();
            v.Agregar(nameof(Categoria.Nombre), "Ya existe una categoría activa con ese nombre.");
            return Resultado<T>.FallaValidacion(v);
        }
    }
}