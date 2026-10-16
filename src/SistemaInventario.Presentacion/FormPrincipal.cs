using System.Globalization;
using FontAwesome.Sharp;
using SistemaInventario.LogicaNegocio;
using SistemaInventario.Presentacion.Estilos;
using SistemaInventario.Presentacion.Vistas;

namespace SistemaInventario.Presentacion
{
    // Ventana principal: menú lateral, barra superior y área de contenido.
    public class FormPrincipal : Form
    {
        private const int AnchoMenu = 270;

        private readonly Panel _contenido = new();
        private readonly Label _tituloVista = new();
        private IconButton? _botonActivo;

        public FormPrincipal(FabricaServicios fabrica)
        {
            Fabrica = fabrica;

            ConfigurarFormulario();

            var areaDerecha = new Panel { Dock = DockStyle.Fill };
            ConstruirBarraSuperior(areaDerecha);
            ConstruirMenuLateral(out var menu, out var botones);

            // Orden importante: primero el control que llena (Fill), después los acoplados a los bordes.
            Controls.Add(areaDerecha);
            Controls.Add(menu);

            // Muestra la primera opción al abrir.
            Load += (_, _) => botones[0].PerformClick();
        }

        // Servicios de negocio; se pasarán a cada vista cuando las construyamos.
        private FabricaServicios Fabrica { get; }

        private void ConfigurarFormulario()
        {
            Text = "InventarioEngine";
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1280, 760);
            MinimumSize = new Size(1000, 640);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Tema.Fondo;
            Font = Tema.FuenteBase;
        }

        // ---------------- Menú lateral ----------------

        private void ConstruirMenuLateral(out Panel menu, out List<IconButton> botones)
        {
            menu = new Panel { Dock = DockStyle.Left, Width = AnchoMenu, BackColor = Tema.Primario };

            var opciones = new (string Texto, IconChar Icono, Func<UserControl> Crear)[]
            {
                ("Inicio",   IconChar.Home,        () => new VistaInicio(Fabrica)),
                ("Productos",  IconChar.Boxes,     () => new VistaProductos(Fabrica)),
                ("Categorías", IconChar.Tags,      () => new VistaCategorias(Fabrica)),
                ("Suplidores", IconChar.Truck,     () => new VistaSuplidores(Fabrica)),
                ("Papelera",   IconChar.Trash,     () => new VistaPapelera(Fabrica)),
                ("Reportes", IconChar.ChartLine, () => new VistaReportes(Fabrica))
            };

            var lista = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BackColor = Tema.Primario,
                Margin = new Padding(0)
            };

            botones = new List<IconButton>();
            foreach (var (texto, icono, crear) in opciones)
            {
                var boton = CrearBotonMenu(texto, icono);
                boton.Click += (_, _) => Navegar(boton, texto, crear);
                lista.Controls.Add(boton);
                botones.Add(boton);
            }

            menu.Controls.Add(lista);
            menu.Controls.Add(CrearLogo());
        }

        private static Panel CrearLogo()
        {
            var logo = new Panel { Dock = DockStyle.Top, Height = 76, BackColor = Tema.Primario };

            logo.Controls.Add(new IconPictureBox
            {
                IconChar = IconChar.Boxes,
                IconColor = Color.White,
                IconSize = 34,
                BackColor = Tema.Primario,
                Size = new Size(38, 38),
                Location = new Point(20, 19)
            });
            logo.Controls.Add(new Label
            {
                Text = "Invent-Engine",
                Font = Tema.FuenteLogo,
                ForeColor = Color.White,
                BackColor = Tema.Primario,
                AutoSize = true,
                Location = new Point(64, 22)
            });
            return logo;
        }

        private static IconButton CrearBotonMenu(string texto, IconChar icono)
        {
            var boton = new IconButton
            {
                Text = "   " + texto,
                IconChar = icono,
                IconColor = Color.White,
                IconSize = 22,
                Size = new Size(AnchoMenu, 48),
                Margin = new Padding(0),
                Padding = new Padding(18, 0, 0, 0),
                FlatStyle = FlatStyle.Flat,
                BackColor = Tema.Primario,
                ForeColor = Color.White,
                Font = Tema.FuenteMenu,
                TextAlign = ContentAlignment.MiddleLeft,
                ImageAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                Cursor = Cursors.Hand
            };
            boton.FlatAppearance.BorderSize = 0;
            boton.FlatAppearance.MouseOverBackColor = Tema.PrimarioHover;
            return boton;
        }

        // ---------------- Barra superior ----------------

        private void ConstruirBarraSuperior(Panel areaDerecha)
        {
            var barra = new Panel { Dock = DockStyle.Top, Height = 64, BackColor = Tema.Superficie };
            barra.Paint += (_, e) =>
                e.Graphics.DrawLine(new Pen(Tema.Borde), 0, barra.Height - 1, barra.Width, barra.Height - 1);

            _tituloVista.Dock = DockStyle.Fill;
            _tituloVista.TextAlign = ContentAlignment.MiddleLeft;
            _tituloVista.Padding = new Padding(24, 0, 0, 0);
            _tituloVista.Font = Tema.FuenteTitulo;
            _tituloVista.ForeColor = Tema.Texto;

            var fecha = new Label
            {
                Dock = DockStyle.Right,
                Width = 340,
                TextAlign = ContentAlignment.MiddleRight,
                Padding = new Padding(0, 0, 24, 0),
                ForeColor = Tema.TextoSuave,
                Text = DateTime.Now.ToString("dddd, d 'de' MMMM 'de' yyyy", new CultureInfo("es-DO"))
            };

            barra.Controls.Add(_tituloVista);
            barra.Controls.Add(fecha);

            _contenido.Dock = DockStyle.Fill;
            _contenido.BackColor = Tema.Fondo;

            areaDerecha.Controls.Add(_contenido);
            areaDerecha.Controls.Add(barra);
        }

        // ---------------- Navegación ----------------

        // Resalta el botón activo y reemplaza la vista del área de contenido.
        private void Navegar(IconButton boton, string titulo, Func<UserControl> crearVista)
        {
            if (_botonActivo != null) _botonActivo.BackColor = Tema.Primario;
            _botonActivo = boton;
            boton.BackColor = Tema.PrimarioOscuro;
            _tituloVista.Text = titulo;

            var anteriores = _contenido.Controls.Cast<Control>().ToList();
            _contenido.Controls.Clear();
            anteriores.ForEach(c => c.Dispose());

            var vista = crearVista();
            vista.Dock = DockStyle.Fill;
            _contenido.Controls.Add(vista);
        }
    }
}