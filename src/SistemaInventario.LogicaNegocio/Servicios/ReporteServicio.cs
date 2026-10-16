using SistemaInventario.AccesoDatos.Interfaces;
using SistemaInventario.LogicaNegocio.Genericos;
using SistemaInventario.LogicaNegocio.Interfaces;

namespace SistemaInventario.LogicaNegocio.Servicios
{
    public class ReporteServicio : ServicioBase, IReporteServicio
    {
        private readonly IProductoRepositorio _productos;
        private readonly ICategoriaRepositorio _categorias;
        private readonly ISuplidorRepositorio _suplidores;

        // Recibe los repositorios por constructor (inyección de dependencias).</summary>
        public ReporteServicio(IProductoRepositorio productos,
                               ICategoriaRepositorio categorias,
                               ISuplidorRepositorio suplidores)
        {
            _productos = productos;
            _categorias = categorias;
            _suplidores = suplidores;
        }

        // LINQ: GroupJoin (left join) de categorías con sus productos, contando cada grupo.</summary>
        public Resultado<List<ItemReporte<int>>> ProductosPorCategoria() =>
            Ejecutar(() =>
            {
                var productos = _productos.ObtenerActivos().ToList();

                var reporte = _categorias.ObtenerActivos()
                    .GroupJoin(productos,
                               categoria => categoria.Id,
                               producto => producto.CategoriaId,
                               (categoria, grupo) => new ItemReporte<int>(categoria.Nombre, grupo.Count()))
                    .OrderByDescending(item => item.Valor)
                    .ThenBy(item => item.Etiqueta)
                    .ToList();

                return Resultado<List<ItemReporte<int>>>.Ok(reporte);
            });

        // LINQ: ranking de suplidores por cantidad de productos activos.</summary>
        public Resultado<List<ItemReporte<int>>> TopSuplidores(int cantidad = 5) =>
            Ejecutar(() =>
            {
                var productos = _productos.ObtenerActivos().ToList();

                var reporte = _suplidores.ObtenerActivos()
                    .GroupJoin(productos,
                               suplidor => suplidor.Id,
                               producto => producto.SuplidorId,
                               (suplidor, grupo) => new ItemReporte<int>(suplidor.NombreEmpresa, grupo.Count()))
                    .OrderByDescending(item => item.Valor)
                    .ThenBy(item => item.Etiqueta)
                    .Take(cantidad)
                    .ToList();

                return Resultado<List<ItemReporte<int>>>.Ok(reporte);
            });

        // LINQ: GroupBy por categoría con Average, unido (Join) al nombre de la categoría.</summary>
        public Resultado<List<ItemReporte<decimal>>> PromedioPrecioPorCategoria() =>
            Ejecutar(() =>
            {
                var categorias = _categorias.ObtenerActivos().ToList();

                var reporte = _productos.ObtenerActivos()
                    .GroupBy(producto => producto.CategoriaId)
                    .Join(categorias,
                          grupo => grupo.Key,
                          categoria => categoria.Id,
                          (grupo, categoria) => new ItemReporte<decimal>(
                              categoria.Nombre, Math.Round(grupo.Average(p => p.Precio), 2)))
                    .OrderBy(item => item.Etiqueta)
                    .ToList();

                return Resultado<List<ItemReporte<decimal>>>.Ok(reporte);
            });
    }
}