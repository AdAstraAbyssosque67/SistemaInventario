using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio;
using SistemaInventario.Presentacion.Estilos;
using SistemaInventario.Presentacion.Formulary;
using System.Globalization;

namespace SistemaInventario.Presentacion.Formularios
{
    // Formulario para crear o editar un producto.
    public class FormProducto : FormularioEdicion
    {
        private readonly FabricaServicios _fabrica;
        private readonly Dictionary<string, Control> _controles;
        private Producto _producto = new();

        private readonly TextBox _txtNombre = new() { MaxLength = 150 };
        private readonly TextBox _txtPrecio = new();
        private readonly ComboBox _cmbCategoria = new() { DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly ComboBox _cmbSuplidor = new() { DropDownStyle = ComboBoxStyle.DropDownList };

        // <param name="productoId">null para crear; el Id del producto para editar.</param>
        public FormProducto(FabricaServicios fabrica, int? productoId)
            : base(productoId.HasValue ? "Editar producto" : "Nuevo producto", new Size(560, 420))
        {
            _fabrica = fabrica;
            _controles = new Dictionary<string, Control>
            {
                [nameof(Producto.Nombre)] = _txtNombre,
                [nameof(Producto.Precio)] = _txtPrecio,
                [nameof(Producto.CategoriaId)] = _cmbCategoria,
                [nameof(Producto.SuplidorId)] = _cmbSuplidor
            };

            AgregarCampo("Nombre del producto", _txtNombre);
            AgregarCampo("Precio unitario (RD$)", _txtPrecio);
            AgregarCampo("Categoría", _cmbCategoria);
            AgregarCampo("Suplidor", _cmbSuplidor);

            if (!CargarDatos(productoId)) Load += (_, _) => Close();
        }

        protected override IReadOnlyDictionary<string, Control> ControlesPorCampo => _controles;

        private bool CargarDatos(int? productoId)
        {
            var categorias = _fabrica.Categorias.ObtenerActivas();
            if (!categorias.Exito) { Dialogos.Error(categorias.Mensaje); return false; }

            var suplidores = _fabrica.Suplidores.ObtenerActivos();
            if (!suplidores.Exito) { Dialogos.Error(suplidores.Mensaje); return false; }

            _cmbCategoria.DataSource = categorias.Valor;
            _cmbCategoria.DisplayMember = nameof(Categoria.Nombre);
            _cmbCategoria.ValueMember = nameof(Categoria.Id);
            _cmbCategoria.SelectedIndex = -1;

            _cmbSuplidor.DataSource = suplidores.Valor;
            _cmbSuplidor.DisplayMember = nameof(Suplidor.NombreEmpresa);
            _cmbSuplidor.ValueMember = nameof(Suplidor.Id);
            _cmbSuplidor.SelectedIndex = -1;

            if (productoId.HasValue)
            {
                var resultado = _fabrica.Productos.ObtenerPorId(productoId.Value);
                if (!resultado.Exito) { Dialogos.Error(resultado.Mensaje); return false; }

                _producto = resultado.Valor!;
                _txtNombre.Text = _producto.Nombre;
                _txtPrecio.Text = _producto.Precio.ToString("0.00", CultureInfo.CurrentCulture);
                _cmbCategoria.SelectedValue = _producto.CategoriaId;
                _cmbSuplidor.SelectedValue = _producto.SuplidorId;
            }
            return true;
        }

        protected override void Guardar()
        {
            LimpiarErrores();

            if (!decimal.TryParse(_txtPrecio.Text.Trim(), NumberStyles.Number,
                                  CultureInfo.CurrentCulture, out decimal precio))
            {
                MarcarError(_txtPrecio, "Ingrese un precio numérico válido.");
                return;
            }

            _producto.Nombre = _txtNombre.Text;
            _producto.Precio = precio;
            _producto.CategoriaId = _cmbCategoria.SelectedValue is int categoriaId ? categoriaId : 0;
            _producto.SuplidorId = _cmbSuplidor.SelectedValue is int suplidorId ? suplidorId : 0;

            if (_producto.Id == 0) Procesar(_fabrica.Productos.Crear(_producto));
            else Procesar(_fabrica.Productos.Actualizar(_producto));
        }
    }
}