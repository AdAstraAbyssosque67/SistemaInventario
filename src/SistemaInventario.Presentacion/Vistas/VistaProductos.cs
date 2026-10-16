using System.Globalization;
using FontAwesome.Sharp;
using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio;
using SistemaInventario.LogicaNegocio.Genericos;
using SistemaInventario.Presentacion.Estilos;
using SistemaInventario.Presentacion.Formularios;
using SistemaInventario.Presentacion.Modelos;

namespace SistemaInventario.Presentacion.Vistas
{
    // Listado de productos con búsqueda en tiempo real y filtros por categoría, suplidor y precio.
    public class VistaProductos : UserControl
    {
        private readonly FabricaServicios _fabrica;
        private readonly TextBox _txtBuscar = new() { PlaceholderText = "Buscar producto...", Width = 300 };
        private readonly ComboBox _cmbCategoria = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 210 };
        private readonly ComboBox _cmbSuplidor = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 210 };
        private readonly TextBox _txtMin = new() { PlaceholderText = "Precio mín.", Width = 110 };
        private readonly TextBox _txtMax = new() { PlaceholderText = "Precio máx.", Width = 110 };
        private readonly Label _lblTotal = new() { AutoSize = true, ForeColor = Tema.TextoSuave };
        private readonly DataGridView _grid = new();

        private List<Producto> _productos = new();
        private Dictionary<int, string> _nombresCategoria = new();
        private Dictionary<int, string> _nombresSuplidor = new();
        private bool _cargando;

        public VistaProductos(FabricaServicios fabrica)
        {
            _fabrica = fabrica;
            Construir();
            CargarDatos();
        }

        private void Construir()
        {
            Dock = DockStyle.Fill;
            BackColor = Tema.Fondo;
            Padding = new Padding(24);

            // Fila 1: búsqueda y acciones
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
            var barra = new Panel { Dock = DockStyle.Top, Height = 56 };
            barra.Controls.Add(acciones);
            barra.Controls.Add(_txtBuscar);

            // Fila 2: filtros
            var btnLimpiar = Estilo.BotonSecundario("Limpiar", IconChar.None, 90);
            btnLimpiar.Height = 30;
            btnLimpiar.Margin = new Padding(0, 3, 12, 0);
            btnLimpiar.Click += (_, _) => LimpiarFiltros();

            foreach (var control in new Control[] { _cmbCategoria, _cmbSuplidor, _txtMin, _txtMax })
                control.Margin = new Padding(0, 4, 12, 0);
            _lblTotal.Margin = new Padding(0, 9, 0, 0);

            var filtros = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 48, WrapContents = false };
            filtros.Controls.AddRange(new Control[]
                { _cmbCategoria, _cmbSuplidor, _txtMin, _txtMax, btnLimpiar, _lblTotal });

            _txtBuscar.TextChanged += (_, _) => AplicarFiltros();
            _cmbCategoria.SelectedIndexChanged += (_, _) => AplicarFiltros();
            _cmbSuplidor.SelectedIndexChanged += (_, _) => AplicarFiltros();
            _txtMin.TextChanged += (_, _) => AplicarFiltros();
            _txtMax.TextChanged += (_, _) => AplicarFiltros();

            // Tabla
            Estilo.AplicarTabla(_grid);
            var colPrecio = Estilo.Columna("Precio (RD$)", nameof(ProductoFila.Precio), 14, "N2");
            colPrecio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _grid.Columns.AddRange(
                Estilo.Columna("Producto", nameof(ProductoFila.Nombre), 30),
                Estilo.Columna("Categoría", nameof(ProductoFila.Categoria), 20),
                Estilo.Columna("Suplidor", nameof(ProductoFila.Suplidor), 22),
                colPrecio,
                Estilo.Columna("Creado", nameof(ProductoFila.FechaCreacion), 14, "dd/MM/yyyy"));
            _grid.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0) Editar(); };

            var tarjeta = new Panel { Dock = DockStyle.Fill, BackColor = Tema.Borde, Padding = new Padding(1) };
            tarjeta.Controls.Add(_grid);

            Controls.Add(tarjeta);   // primero el que llena; el último agregado queda arriba
            Controls.Add(filtros);
            Controls.Add(barra);
        }

        // ---------------- Datos ----------------

        private void CargarDatos()
        {
            var productos = _fabrica.Productos.ObtenerActivos();
            var categorias = _fabrica.Categorias.ObtenerActivas();
            var suplidores = _fabrica.Suplidores.ObtenerActivos();
            if (Fallo(productos) || Fallo(categorias) || Fallo(suplidores)) return;

            _productos = productos.Valor!;
            _nombresCategoria = categorias.Valor!.ToDictionary(c => c.Id, c => c.Nombre);
            _nombresSuplidor = suplidores.Valor!.ToDictionary(s => s.Id, s => s.NombreEmpresa);

            // Conserva los filtros elegidos al recargar
            int categoriaActual = ValorSeleccionado(_cmbCategoria) ?? 0;
            int suplidorActual = ValorSeleccionado(_cmbSuplidor) ?? 0;

            _cargando = true;
            Rellenar(_cmbCategoria,
                categorias.Valor!.Prepend(new Categoria { Id = 0, Nombre = "Todas las categorías" }).ToList(),
                nameof(Categoria.Nombre));
            Rellenar(_cmbSuplidor,
                suplidores.Valor!.Prepend(new Suplidor { Id = 0, NombreEmpresa = "Todos los suplidores" }).ToList(),
                nameof(Suplidor.NombreEmpresa));
            _cmbCategoria.SelectedValue = categoriaActual;
            _cmbSuplidor.SelectedValue = suplidorActual;
            _cargando = false;

            AplicarFiltros();
        }

        // Método genérico: llena un ComboBox con cualquier lista de objetos que tengan Id.
        private static void Rellenar<T>(ComboBox combo, List<T> elementos, string propiedadMostrar)
        {
            combo.DataSource = elementos;
            combo.DisplayMember = propiedadMostrar;
            combo.ValueMember = "Id";
        }

        private static bool Fallo<T>(Resultado<T> resultado)
        {
            if (resultado.Exito) return false;
            Dialogos.Error(resultado.Mensaje);
            return true;
        }

        private void AplicarFiltros()
        {
            if (_cargando) return;

            var filas = _fabrica.Productos
                .Filtrar(_productos, _txtBuscar.Text,
                         ValorSeleccionado(_cmbCategoria), ValorSeleccionado(_cmbSuplidor),
                         LeerPrecio(_txtMin), LeerPrecio(_txtMax))
                .Select(p => new ProductoFila(
                    p.Id, p.Nombre,
                    _nombresCategoria.GetValueOrDefault(p.CategoriaId, "—"),
                    _nombresSuplidor.GetValueOrDefault(p.SuplidorId, "—"),
                    p.Precio, p.FechaCreacion))
                .ToList();

            _grid.DataSource = filas;
            _lblTotal.Text = $"{filas.Count} producto(s)";
        }

        private static int? ValorSeleccionado(ComboBox combo) =>
            combo.SelectedValue is int id && id > 0 ? id : null;

        private static decimal? LeerPrecio(TextBox caja) =>
            decimal.TryParse(caja.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out var valor)
                ? valor : null;

        private void LimpiarFiltros()
        {
            _cargando = true;
            _txtBuscar.Clear();
            _txtMin.Clear();
            _txtMax.Clear();
            _cmbCategoria.SelectedValue = 0;
            _cmbSuplidor.SelectedValue = 0;
            _cargando = false;
            AplicarFiltros();
        }

        // ---------------- Acciones ----------------

        private ProductoFila? Seleccionado() => _grid.CurrentRow?.DataBoundItem as ProductoFila;

        private void Nuevo()
        {
            using var form = new FormProducto(_fabrica, null);
            if (form.ShowDialog(FindForm()) == DialogResult.OK) CargarDatos();
        }

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

        private void Eliminar()
        {
            var fila = Seleccionado();
            if (fila is null)
            {
                Dialogos.Info("Seleccione un producto de la lista.");
                return;
            }
            if (!Dialogos.Confirmar($"¿Eliminar el producto '{fila.Nombre}'?\r\nPodrá restaurarlo desde la Papelera."))
                return;

            var resultado = _fabrica.Productos.Eliminar(fila.Id);
            if (!resultado.Exito)
            {
                Dialogos.Error(resultado.Mensaje);
                return;
            }
            CargarDatos();
        }
    }
}