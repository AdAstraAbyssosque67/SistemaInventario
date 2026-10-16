using FontAwesome.Sharp;
using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio;
using SistemaInventario.Presentacion.Estilos;
using SistemaInventario.Presentacion.Formularios;

namespace SistemaInventario.Presentacion.Vistas
{
    /// <summary>Listado de suplidores con búsqueda en tiempo real y acciones.</summary>
    public class VistaSuplidores : UserControl
    {
        private readonly FabricaServicios _fabrica;
        private readonly TextBox _txtBuscar = new() { PlaceholderText = "Buscar suplidor...", Width = 320 };
        private readonly DataGridView _grid = new();
        private List<Suplidor> _suplidores = new();

        public VistaSuplidores(FabricaServicios fabrica)
        {
            _fabrica = fabrica;
            Construir();
            Recargar();
        }

        private void Construir()
        {
            Dock = DockStyle.Fill;
            BackColor = Tema.Fondo;
            Padding = new Padding(24);

            var btnEditar = Estilo.BotonSecundario("Editar", IconChar.Pen, 110);
            var btnEliminar = Estilo.BotonPeligro("Eliminar", IconChar.Trash, 120);
            var btnNuevo = Estilo.BotonPrimario("Nuevo", IconChar.Plus, 110);
            btnNuevo.Click += (_, _) => Nuevo();
            btnEditar.Click += (_, _) => Editar();
            btnEliminar.Click += (_, _) => Eliminar();

            var acciones = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                WrapContents = false,
                Padding = new Padding(0, 9, 0, 0)
            };
            acciones.Controls.AddRange(new Control[] { btnEditar, btnEliminar, btnNuevo });

            _txtBuscar.Location = new Point(0, 13);
            _txtBuscar.TextChanged += (_, _) => AplicarFiltro();

            var barra = new Panel { Dock = DockStyle.Top, Height = 56 };
            barra.Controls.Add(acciones);
            barra.Controls.Add(_txtBuscar);

            Estilo.AplicarTabla(_grid);
            _grid.Columns.AddRange(
                Estilo.Columna("Empresa", nameof(Suplidor.NombreEmpresa), 24),
                Estilo.Columna("Contacto", nameof(Suplidor.NombreContacto), 18),
                Estilo.Columna("Teléfono", nameof(Suplidor.Telefono), 14),
                Estilo.Columna("Correo", nameof(Suplidor.Email), 24),
                Estilo.Columna("Sitio web", nameof(Suplidor.SitioWeb), 20));
            _grid.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0) Editar(); };

            var tarjeta = new Panel { Dock = DockStyle.Fill, BackColor = Tema.Borde, Padding = new Padding(1) };
            tarjeta.Controls.Add(_grid);

            Controls.Add(tarjeta);
            Controls.Add(barra);
        }

        private void Recargar()
        {
            var resultado = _fabrica.Suplidores.ObtenerActivos();
            if (!resultado.Exito)
            {
                Dialogos.Error(resultado.Mensaje);
                return;
            }
            _suplidores = resultado.Valor!;
            AplicarFiltro();
        }

        private void AplicarFiltro() =>
            _grid.DataSource = _fabrica.Suplidores.Filtrar(_suplidores, _txtBuscar.Text).ToList();

        private Suplidor? Seleccionado() => _grid.CurrentRow?.DataBoundItem as Suplidor;

        private void Nuevo()
        {
            using var form = new FormSuplidor(_fabrica, null);
            if (form.ShowDialog(FindForm()) == DialogResult.OK) Recargar();
        }

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

        private void Eliminar()
        {
            var suplidor = Seleccionado();
            if (suplidor is null)
            {
                Dialogos.Info("Seleccione un suplidor de la lista.");
                return;
            }
            if (!Dialogos.Confirmar($"¿Eliminar el suplidor '{suplidor.NombreEmpresa}'?\r\nPodrá restaurarlo desde la Papelera."))
                return;

            var resultado = _fabrica.Suplidores.Eliminar(suplidor.Id);
            if (!resultado.Exito)
            {
                Dialogos.Error(resultado.Mensaje);   // por ejemplo: tiene productos activos
                return;
            }
            Recargar();
        }
    }
}