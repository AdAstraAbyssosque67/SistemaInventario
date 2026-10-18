using System.Globalization;
using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio;
using SistemaInventario.Presentacion.Estilos;

namespace SistemaInventario.Presentacion.Formularios
{
    // Formulario para crear o editar un producto.
    public partial class FormProducto : FormularioEdicion
    {
        private readonly FabricaServicios _fabrica;
        private readonly Dictionary<string, Control> _controles;
        private Producto _producto = new();

        // productoId: null para crear; el Id del producto para editar.
        public FormProducto(FabricaServicios fabrica, int? productoId)
        {
            _fabrica = fabrica;
            InitializeComponent();

            _controles = new Dictionary<string, Control>
            {
                [nameof(Producto.Nombre)] = txtNombre,
                [nameof(Producto.Precio)] = txtPrecio,
                [nameof(Producto.CategoriaId)] = cmbCategoria,
                [nameof(Producto.SuplidorId)] = cmbSuplidor
            };

            if (productoId.HasValue) Text = "Editar producto";
            if (!CargarDatos(productoId)) Load += (_, _) => Close();
        }

        protected override IReadOnlyDictionary<string, Control> ControlesPorCampo => _controles;

        private bool CargarDatos(int? productoId)
        {
            var categorias = _fabrica.Categorias.ObtenerActivas();
            if (Dialogos.HayError(categorias)) return false;

            var suplidores = _fabrica.Suplidores.ObtenerActivos();
            if (Dialogos.HayError(suplidores)) return false;

            cmbCategoria.DataSource = categorias.Valor;
            cmbCategoria.DisplayMember = nameof(Categoria.Nombre);
            cmbCategoria.ValueMember = nameof(Categoria.Id);
            cmbCategoria.SelectedIndex = -1;

            cmbSuplidor.DataSource = suplidores.Valor;
            cmbSuplidor.DisplayMember = nameof(Suplidor.NombreEmpresa);
            cmbSuplidor.ValueMember = nameof(Suplidor.Id);
            cmbSuplidor.SelectedIndex = -1;

            if (productoId.HasValue)
            {
                var resultado = _fabrica.Productos.ObtenerPorId(productoId.Value);
                if (Dialogos.HayError(resultado)) return false;

                _producto = resultado.Valor!;
                txtNombre.Text = _producto.Nombre;
                txtPrecio.Text = _producto.Precio.ToString("0.00", CultureInfo.CurrentCulture);
                cmbCategoria.SelectedValue = _producto.CategoriaId;
                cmbSuplidor.SelectedValue = _producto.SuplidorId;
            }
            return true;
        }

        protected override void Guardar()
        {
            LimpiarErrores();

            if (!decimal.TryParse(txtPrecio.Text.Trim(), NumberStyles.Number,
                                  CultureInfo.CurrentCulture, out decimal precio))
            {
                MarcarError(txtPrecio, "Ingrese un precio numérico válido.");
                return;
            }

            _producto.Nombre = txtNombre.Text;
            _producto.Precio = precio;
            _producto.CategoriaId = cmbCategoria.SelectedValue is int categoriaId ? categoriaId : 0;
            _producto.SuplidorId = cmbSuplidor.SelectedValue is int suplidorId ? suplidorId : 0;

            if (_producto.Id == 0) Procesar(_fabrica.Productos.Crear(_producto));
            else Procesar(_fabrica.Productos.Actualizar(_producto));
        }
    }
}
