using System.Globalization;
using FontAwesome.Sharp;
using SistemaInventario.LogicaNegocio;
using SistemaInventario.Presentacion.Estilos;
using SistemaInventario.Presentacion.Vistas;

namespace SistemaInventario.Presentacion
{
    // Ventana principal: menú lateral, barra superior y área de contenido.
    public partial class FormPrincipal : Form
    {
        private readonly Dictionary<IconButton, Func<UserControl>> _vistas;
        private IconButton? _botonActivo;

        public FormPrincipal(FabricaServicios fabrica)
        {
            InitializeComponent();

            _vistas = new Dictionary<IconButton, Func<UserControl>>
            {
                [btnInicio] = () => new VistaInicio(fabrica),
                [btnProductos] = () => new VistaProductos(fabrica),
                [btnCategorias] = () => new VistaCategorias(fabrica),
                [btnSuplidores] = () => new VistaSuplidores(fabrica),
                [btnPapelera] = () => new VistaPapelera(fabrica),
                [btnReportes] = () => new VistaReportes(fabrica)
            };

            lblFecha.Text = DateTime.Now.ToString("dddd, d 'de' MMMM 'de' yyyy", new CultureInfo("es-DO"));
        }

        // Muestra la primera opción al abrir.
        private void FormPrincipal_Load(object? sender, EventArgs e) => Navegar(btnInicio);

        private void btnMenu_Click(object? sender, EventArgs e)
        {
            if (sender is IconButton boton) Navegar(boton);
        }

        // Resalta el botón activo y reemplaza la vista del área de contenido.
        private void Navegar(IconButton boton)
        {
            if (_botonActivo != null) _botonActivo.BackColor = Tema.Primario;
            _botonActivo = boton;
            boton.BackColor = Tema.PrimarioOscuro;
            lblTituloVista.Text = boton.Text.Trim();

            var anteriores = pnlContenido.Controls.Cast<Control>().ToList();
            pnlContenido.Controls.Clear();
            anteriores.ForEach(c => c.Dispose());

            var vista = _vistas[boton]();
            vista.Dock = DockStyle.Fill;
            pnlContenido.Controls.Add(vista);
        }
    }
}
