using SistemaInventario.AccesoDatos.Interfaces;
using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio.Genericos;
using SistemaInventario.LogicaNegocio.Interfaces;
using SistemaInventario.LogicaNegocio.Validaciones;

namespace SistemaInventario.LogicaNegocio.Servicios
{
    public class SuplidorServicio : ServicioBase, ISuplidorServicio
    {
        private readonly ISuplidorRepositorio _repositorio;

        // Recibe el repositorio por constructor (inyección de dependencias).
        public SuplidorServicio(ISuplidorRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Resultado<List<Suplidor>> ObtenerActivos() =>
            Ejecutar(() => Resultado<List<Suplidor>>.Ok(_repositorio.ObtenerActivos().ToList()));

        public Resultado<List<Suplidor>> ObtenerEliminados() =>
            Ejecutar(() => Resultado<List<Suplidor>>.Ok(_repositorio.ObtenerEliminados().ToList()));

        public Resultado<Suplidor> ObtenerPorId(int id) =>
            Ejecutar(() =>
            {
                var suplidor = _repositorio.ObtenerPorId(id);
                return suplidor is null
                    ? Resultado<Suplidor>.Falla("El suplidor no existe.")
                    : Resultado<Suplidor>.Ok(suplidor);
            });

        public Resultado<int> Crear(Suplidor suplidor)
        {
            Normalizar(suplidor);
            var validacion = Validador.ValidarSuplidor(suplidor);
            if (!validacion.EsValido) return Resultado<int>.FallaValidacion(validacion);

            return Ejecutar(() =>
            {
                if (_repositorio.ExisteNombreEmpresa(suplidor.NombreEmpresa))
                    return NombreDuplicado<int>();

                return Resultado<int>.Ok(_repositorio.Agregar(suplidor));
            });
        }

        public Resultado<bool> Actualizar(Suplidor suplidor)
        {
            Normalizar(suplidor);
            var validacion = Validador.ValidarSuplidor(suplidor);
            if (!validacion.EsValido) return Resultado<bool>.FallaValidacion(validacion);

            return Ejecutar(() =>
            {
                var existente = _repositorio.ObtenerPorId(suplidor.Id);
                if (existente is null || !existente.Activo)
                    return Resultado<bool>.Falla("El suplidor no existe o está en la papelera.");

                if (_repositorio.ExisteNombreEmpresa(suplidor.NombreEmpresa, suplidor.Id))
                    return NombreDuplicado<bool>();

                _repositorio.Actualizar(suplidor);
                return Resultado<bool>.Ok(true);
            });
        }

        public Resultado<bool> Eliminar(int id) =>
            Ejecutar(() =>
            {
                if (_repositorio.TieneProductosActivos(id))
                    return Resultado<bool>.Falla("No se puede eliminar: el suplidor tiene productos activos asociados.");

                _repositorio.Eliminar(id);
                return Resultado<bool>.Ok(true);
            });

        public Resultado<bool> Restaurar(int id) =>
            Ejecutar(() =>
            {
                var suplidor = _repositorio.ObtenerPorId(id);
                if (suplidor is null) return Resultado<bool>.Falla("El suplidor no existe.");

                if (_repositorio.ExisteNombreEmpresa(suplidor.NombreEmpresa, suplidor.Id))
                    return Resultado<bool>.Falla(
                        $"No se puede restaurar: ya existe un suplidor activo llamado '{suplidor.NombreEmpresa}'.");

                _repositorio.Restaurar(id);
                return Resultado<bool>.Ok(true);
            });

        // LINQ: búsqueda parcial por empresa, contacto, correo o teléfono, ignorando mayúsculas.
        public IEnumerable<Suplidor> Filtrar(IEnumerable<Suplidor> suplidores, string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return suplidores;
            string busqueda = texto.Trim();
            return suplidores.Where(s =>
                s.NombreEmpresa.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                s.NombreContacto.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                s.Email.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                s.Telefono.Contains(busqueda));
        }

        private static void Normalizar(Suplidor suplidor)
        {
            suplidor.NombreEmpresa = suplidor.NombreEmpresa?.Trim() ?? string.Empty;
            suplidor.NombreContacto = suplidor.NombreContacto?.Trim() ?? string.Empty;
            suplidor.Telefono = suplidor.Telefono?.Trim() ?? string.Empty;
            suplidor.Email = suplidor.Email?.Trim() ?? string.Empty;
            suplidor.SitioWeb = string.IsNullOrWhiteSpace(suplidor.SitioWeb) ? null : suplidor.SitioWeb.Trim();
        }

        private static Resultado<T> NombreDuplicado<T>()
        {
            var v = new ResultadoValidacion();
            v.Agregar(nameof(Suplidor.NombreEmpresa), "Ya existe un suplidor activo con ese nombre.");
            return Resultado<T>.FallaValidacion(v);
        }
    }
}