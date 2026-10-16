using FontAwesome.Sharp;
using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio;
using SistemaInventario.Presentacion.Estilos;
using SistemaInventario.Presentacion.Formulary;

namespace SistemaInventario.Presentacion.Vistas
{
    /// <summary>Listado de categorías con búsqueda en tiempo real y acciones.</summary>
    public class VistaCategorias : UserControl
    {
        private readonly FabricaServicios _fabrica;
        private readonly TextBox _txtBuscar = new() { PlaceholderText = "Buscar categoría...", Width = 320 };
        private readonly DataGridView _grid = new();
        private List<Categoria> _categorias = new();

        public VistaCategorias(FabricaServicios fabrica)
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
            btnNuevo.Click += (_, _) => Nueva();
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
                Estilo.Columna("Nombre", nameof(Categoria.Nombre), 25),
                Estilo.Columna("Descripción", nameof(Categoria.Descripcion), 50),
                Estilo.Columna("Creada", nameof(Categoria.FechaCreacion), 15, "dd/MM/yyyy"),
                Estilo.Columna("Modificada", nameof(Categoria.FechaModificacion), 15, "dd/MM/yyyy"));
            _grid.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0) Editar(); };

            var tarjeta = new Panel { Dock = DockStyle.Fill, BackColor = Tema.Borde, Padding = new Padding(1) };
            tarjeta.Controls.Add(_grid);

            Controls.Add(tarjeta);   // primero el que llena
            Controls.Add(barra);
        }

        private void Recargar()
        {
            var resultado = _fabrica.Categorias.ObtenerActivas();
            if (!resultado.Exito)
            {
                Dialogos.Error(resultado.Mensaje);
                return;
            }
            _categorias = resultado.Valor!;
            AplicarFiltro();
        }

        private void AplicarFiltro() =>
            _grid.DataSource = _fabrica.Categorias.Filtrar(_categorias, _txtBuscar.Text).ToList();

        private Categoria? Seleccionada() => _grid.CurrentRow?.DataBoundItem as Categoria;

        private void Nueva()
        {
            using var form = new FormCategoria(_fabrica, null);
            if (form.ShowDialog(FindForm()) == DialogResult.OK) Recargar();
        }

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

        private void Eliminar()
        {
            var categoria = Seleccionada();
            if (categoria is null)
            {
                Dialogos.Info("Seleccione una categoría de la lista.");
                return;
            }
            if (!Dialogos.Confirmar($"¿Eliminar la categoría '{categoria.Nombre}'?\r\nPodrá restaurarla desde la Papelera."))
                return;

            var resultado = _fabrica.Categorias.Eliminar(categoria.Id);
            if (!resultado.Exito)
            {
                Dialogos.Error(resultado.Mensaje);   // por ejemplo: tiene productos activos
                return;
            }
            Recargar();
        }
    }
}