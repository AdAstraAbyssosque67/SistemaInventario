using System.Globalization;
using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio;
using SistemaInventario.Presentacion.Estilos;
using SistemaInventario.Presentacion.Formularios;
using SistemaInventario.Presentacion.Modelos;

namespace SistemaInventario.Presentacion.Vistas
{
    // Listado de productos con búsqueda en tiempo real y filtros por categoría, suplidor y precio.
    public partial class VistaProductos : UserControl
    {
        private readonly FabricaServicios _fabrica;
        private List<Producto> _productos = new();
        private Dictionary<int, string> _nombresCategoria = new();
        private Dictionary<int, string> _nombresSuplidor = new();
        private bool _cargando;

        public VistaProductos(FabricaServicios fabrica)
        {
            _fabrica = fabrica;
            InitializeComponent();
            CargarDatos();
        }

        // ---------------- Datos ----------------

        private void CargarDatos()
        {
            var productos = _fabrica.Productos.ObtenerActivos();
            var categorias = _fabrica.Categorias.ObtenerActivas();
            var suplidores = _fabrica.Suplidores.ObtenerActivos();
            if (Dialogos.HayError(productos) || Dialogos.HayError(categorias) || Dialogos.HayError(suplidores))
                return;

            _productos = productos.Valor!;
            _nombresCategoria = categorias.Valor!.ToDictionary(c => c.Id, c => c.Nombre);
            _nombresSuplidor = suplidores.Valor!.ToDictionary(s => s.Id, s => s.NombreEmpresa);

            // Conserva los filtros elegidos al recargar.
            int categoriaActual = ValorSeleccionado(cmbCategoria) ?? 0;
            int suplidorActual = ValorSeleccionado(cmbSuplidor) ?? 0;

            _cargando = true;
            Rellenar(cmbCategoria,
                categorias.Valor!.Prepend(new Categoria { Id = 0, Nombre = "Todas las categorías" }).ToList(),
                nameof(Categoria.Nombre));
            Rellenar(cmbSuplidor,
                suplidores.Valor!.Prepend(new Suplidor { Id = 0, NombreEmpresa = "Todos los suplidores" }).ToList(),
                nameof(Suplidor.NombreEmpresa));
            cmbCategoria.SelectedValue = categoriaActual;
            cmbSuplidor.SelectedValue = suplidorActual;
            _cargando = false;

            AplicarFiltros();
        }

        // Llena un ComboBox con cualquier lista de objetos que tengan Id.
        private static void Rellenar<T>(ComboBox combo, List<T> elementos, string propiedadMostrar)
        {
            combo.DataSource = elementos;
            combo.DisplayMember = propiedadMostrar;
            combo.ValueMember = "Id";
        }

        private void AplicarFiltros()
        {
            if (_cargando) return;

            var filas = _fabrica.Productos
                .Filtrar(_productos, campoBusqueda.Text,
                         ValorSeleccionado(cmbCategoria), ValorSeleccionado(cmbSuplidor),
                         LeerPrecio(txtMin), LeerPrecio(txtMax))
                .Select(p => new ProductoFila(
                    p.Id, p.Nombre,
                    _nombresCategoria.GetValueOrDefault(p.CategoriaId, "—"),
                    _nombresSuplidor.GetValueOrDefault(p.SuplidorId, "—"),
                    p.Precio, p.FechaCreacion))
                .ToList();

            grid.DataSource = filas;
            lblTotal.Text = $"{filas.Count} producto(s)";
        }

        private static int? ValorSeleccionado(ComboBox combo) =>
            combo.SelectedValue is int id && id > 0 ? id : null;

        private static decimal? LeerPrecio(TextBox caja) =>
            decimal.TryParse(caja.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out var valor)
                ? valor : null;

        // ---------------- Eventos ----------------

        private void filtro_Changed(object? sender, EventArgs e) => AplicarFiltros();

        private void btnLimpiar_Click(object? sender, EventArgs e)
        {
            _cargando = true;
            campoBusqueda.Text = string.Empty;
            txtMin.Clear();
            txtMax.Clear();
            cmbCategoria.SelectedValue = 0;
            cmbSuplidor.SelectedValue = 0;
            _cargando = false;
            AplicarFiltros();
        }

        private void grid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) Editar();
        }

        private ProductoFila? Seleccionado() => grid.CurrentRow?.DataBoundItem as ProductoFila;

        private void btnNuevo_Click(object? sender, EventArgs e)
        {
            using var form = new FormProducto(_fabrica, null);
            if (form.ShowDialog(FindForm()) == DialogResult.OK) CargarDatos();
        }

        private void btnEditar_Click(object? sender, EventArgs e) => Editar();

        private void Editar()
        {
            var fila = Seleccionado();
            if (fila is null)
            {
                Dialogos.Info("Seleccione un producto de la lista.");
                return;
            }
            using var form = new FormProducto(_fabrica, fila.Id);
            if (form.ShowDialog(FindForm()) == DialogResult.OK) CargarDatos();
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            var fila = Seleccionado();
            if (fila is null)
            {
                Dialogos.Info("Seleccione un producto de la lista.");
                return;
            }
            if (!Dialogos.Confirmar($"¿Eliminar el producto '{fila.Nombre}'?\r\nPodrá restaurarlo desde la Papelera."))
                return;

            if (Dialogos.HayError(_fabrica.Productos.Eliminar(fila.Id))) return;
            CargarDatos();
        }
    }
}
