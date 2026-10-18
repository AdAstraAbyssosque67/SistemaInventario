using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio;
using SistemaInventario.Presentacion.Estilos;
using SistemaInventario.Presentacion.Formularios;

namespace SistemaInventario.Presentacion.Vistas
{
    // Listado de categorías con búsqueda en tiempo real y acciones.
    public partial class VistaCategorias : UserControl
    {
        private readonly FabricaServicios _fabrica;
        private List<Categoria> _categorias = new();

        public VistaCategorias(FabricaServicios fabrica)
        {
            _fabrica = fabrica;
            InitializeComponent();
            Recargar();
        }

        private void Recargar()
        {
            var resultado = _fabrica.Categorias.ObtenerActivas();
            if (Dialogos.HayError(resultado)) return;

            _categorias = resultado.Valor!;
            AplicarFiltro();
        }

        private void AplicarFiltro() =>
            grid.DataSource = _fabrica.Categorias.Filtrar(_categorias, campoBusqueda.Text).ToList();

        private Categoria? Seleccionada() => grid.CurrentRow?.DataBoundItem as Categoria;

        private void campoBusqueda_TextChanged(object? sender, EventArgs e) => AplicarFiltro();

        private void grid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) Editar();
        }

        private void btnNuevo_Click(object? sender, EventArgs e)
        {
            using var form = new FormCategoria(_fabrica, null);
            if (form.ShowDialog(FindForm()) == DialogResult.OK) Recargar();
        }

        private void btnEditar_Click(object? sender, EventArgs e) => Editar();

        private void Editar()
        {
            var categoria = Seleccionada();
            if (categoria is null)
            {
                Dialogos.Info("Seleccione una categoría de la lista.");
                return;
            }
            using var form = new FormCategoria(_fabrica, categoria.Id);
            if (form.ShowDialog(FindForm()) == DialogResult.OK) Recargar();
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            var categoria = Seleccionada();
            if (categoria is null)
            {
                Dialogos.Info("Seleccione una categoría de la lista.");
                return;
            }
            if (!Dialogos.Confirmar($"¿Eliminar la categoría '{categoria.Nombre}'?\r\nPodrá restaurarla desde la Papelera."))
                return;

            // Falla, por ejemplo, si la categoría tiene productos activos.
            if (Dialogos.HayError(_fabrica.Categorias.Eliminar(categoria.Id))) return;
            Recargar();
        }
    }
}
