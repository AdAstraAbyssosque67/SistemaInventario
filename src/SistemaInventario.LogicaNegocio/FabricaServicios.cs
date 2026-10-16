using SistemaInventario.AccesoDatos.Conexion;
using SistemaInventario.AccesoDatos.Repositorios;
using SistemaInventario.LogicaNegocio.Interfaces;
using SistemaInventario.LogicaNegocio.Servicios;

namespace SistemaInventario.LogicaNegocio
{
    // Compone las capas: crea los repositorios y los inyecta en los servicios.
    public class FabricaServicios
    {
        //  name="cadenaConexion">Opcional. Si es null se usa la cadena por defecto (localhost).
        public FabricaServicios(string? cadenaConexion = null)
        {
            if (!string.IsNullOrWhiteSpace(cadenaConexion))
                ConexionBD.Instancia.Configurar(cadenaConexion);

            var categorias = new CategoriaRepositorio();
            var suplidores = new SuplidorRepositorio();
            var productos = new ProductoRepositorio();

            Categorias = new CategoriaServicio(categorias);
            Suplidores = new SuplidorServicio(suplidores);
            Productos = new ProductoServicio(productos, categorias, suplidores);
            Reportes = new ReporteServicio(productos, categorias, suplidores);
        }

        public ICategoriaServicio Categorias { get; }
        public ISuplidorServicio Suplidores { get; }
        public IProductoServicio Productos { get; }
        public IReporteServicio Reportes { get; }
    }
}