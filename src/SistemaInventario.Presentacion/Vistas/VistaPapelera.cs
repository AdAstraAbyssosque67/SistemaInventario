using SistemaInventario.LogicaNegocio;
using SistemaInventario.LogicaNegocio.Genericos;
using SistemaInventario.Presentacion.Controles;
using SistemaInventario.Presentacion.Estilos;
using SistemaInventario.Presentacion.Modelos;

namespace SistemaInventario.Presentacion.Vistas
{
    // Papelera: muestra los registros eliminados y permite restaurarlos.
    public partial class VistaPapelera : UserControl
    {
        // Un tipo de registro: cómo cargar sus eliminados y cómo restaurarlos.
        private record Origen(Func<Resultado<List<ElementoPapelera>>> Cargar,
                              Func<int, Resultado<bool>> Restaurar);

        private readonly Dictionary<BotonPestana, Origen> _origenes;
        private Origen _origenActual;
        private List<ElementoPapelera> _elementos = new();

        public VistaPapelera(FabricaServicios fabrica)
        {
            InitializeComponent();

            _origenes = new Dictionary<BotonPestana, Origen>
            {
                [rbtnProductos] = new(
                    () => Convertir(fabrica.Productos.ObtenerEliminados(),
                        p => new ElementoPapelera(p.Id, p.Nombre, $"Precio: RD$ {p.Precio:N2}", p.FechaModificacion)),
                    id => fabrica.Productos.Restaurar(id)),

                [rbtnCategorias] = new(
                    () => Convertir(fabrica.Categorias.ObtenerEliminadas(),
                        c => new ElementoPapelera(c.Id, c.Nombre, c.Descripcion, c.FechaModificacion)),
                    id => fabrica.Categorias.Restaurar(id)),

                [rbtnSuplidores] = new(
                    () => Convertir(fabrica.Suplidores.ObtenerEliminados(),
                        s => new ElementoPapelera(s.Id, s.NombreEmpresa, $"{s.NombreContacto} · {s.Telefono}", s.FechaModificacion)),
                    id => fabrica.Suplidores.Restaurar(id))
            };
            _origenActual = _origenes[rbtnProductos];

            rbtnProductos.Checked = true;   // muestra Productos al abrir
        }

        // Convierte el resultado de cualquier servicio en filas de la papelera.
        private static Resultado<List<ElementoPapelera>> Convertir<T>(
            Resultado<List<T>> origen, Func<T, ElementoPapelera> mapa) =>
            origen.Exito
                ? Resultado<List<ElementoPapelera>>.Ok(origen.Valor!.Select(mapa).ToList())
                : Resultado<List<ElementoPapelera>>.Falla(origen.Mensaje);

        private void rbtnOrigen_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender is not BotonPestana { Checked: true } pestana) return;
            _origenActual = _origenes[pestana];
            Recargar();
        }

        private void Recargar()
        {
            var resultado = _origenActual.Cargar();
            if (Dialogos.HayError(resultado)) return;

            _elementos = resultado.Valor!;
            AplicarFiltro();
        }

        private void campoBusqueda_TextChanged(object? sender, EventArgs e) => AplicarFiltro();

        // Búsqueda parcial por nombre o detalle, ignorando mayúsculas.
        private void AplicarFiltro()
        {
            string texto = campoBusqueda.Text.Trim();
            grid.DataSource = _elementos
                .Where(e => texto.Length == 0
                         || e.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase)
                         || e.Detalle.Contains(texto, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        private void btnRestaurar_Click(object? sender, EventArgs e)
        {
            if (grid.CurrentRow?.DataBoundItem is not ElementoPapelera elemento)
            {
                Dialogos.Info("Seleccione un elemento de la lista.");
                return;
            }

            // Falla, por ejemplo, si su categoría sigue en la papelera.
            if (Dialogos.HayError(_origenActual.Restaurar(elemento.Id))) return;
            Recargar();
        }
    }
}
