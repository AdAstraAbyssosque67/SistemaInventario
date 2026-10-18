using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio;
using SistemaInventario.Presentacion.Estilos;
using SistemaInventario.Presentacion.Formularios;

namespace SistemaInventario.Presentacion.Vistas
{
    // Listado de suplidores con búsqueda en tiempo real y acciones.
    public partial class VistaSuplidores : UserControl
    {
        private readonly FabricaServicios _fabrica;
        private List<Suplidor> _suplidores = new();

        public VistaSuplidores(FabricaServicios fabrica)
        {
            _fabrica = fabrica;
            InitializeComponent();
            Recargar();
        }

        private void Recargar()
        {
            var resultado = _fabrica.Suplidores.ObtenerActivos();
            if (Dialogos.HayError(resultado)) return;

            _suplidores = resultado.Valor!;
            AplicarFiltro();
        }

        private void AplicarFiltro() =>
            grid.DataSource = _fabrica.Suplidores.Filtrar(_suplidores, campoBusqueda.Text).ToList();

        private Suplidor? Seleccionado() => grid.CurrentRow?.DataBoundItem as Suplidor;

        private void campoBusqueda_TextChanged(object? sender, EventArgs e) => AplicarFiltro();

        private void grid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) Editar();
        }

        private void btnNuevo_Click(object? sender, EventArgs e)
        {
            using var form = new FormSuplidor(_fabrica, null);
            if (form.ShowDialog(FindForm()) == DialogResult.OK) Recargar();
        }

        private void btnEditar_Click(object? sender, EventArgs e) => Editar();

        private void Editar()
        {
            var suplidor = Seleccionado();
            if (suplidor is null)
            {
                Dialogos.Info("Seleccione un suplidor de la lista.");
                return;
            }
            using var form = new FormSuplidor(_fabrica, suplidor.Id);
            if (form.ShowDialog(FindForm()) == DialogResult.OK) Recargar();
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            var suplidor = Seleccionado();
            if (suplidor is null)
            {
                Dialogos.Info("Seleccione un suplidor de la lista.");
                return;
            }
            if (!Dialogos.Confirmar($"¿Eliminar el suplidor '{suplidor.NombreEmpresa}'?\r\nPodrá restaurarlo desde la Papelera."))
                return;

            // Falla, por ejemplo, si el suplidor tiene productos activos.
            if (Dialogos.HayError(_fabrica.Suplidores.Eliminar(suplidor.Id))) return;
            Recargar();
        }
    }
}
