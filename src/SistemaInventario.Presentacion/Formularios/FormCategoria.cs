using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio;
using SistemaInventario.LogicaNegocio.Validaciones;
using SistemaInventario.Presentacion.Estilos;

namespace SistemaInventario.Presentacion.Formularios
{
    // Formulario para crear o editar una categoría, con hasta 5 fotos.
    public partial class FormCategoria : FormularioEdicion
    {
        private static readonly Font FuenteQuitar = new("Segoe UI", 7F);

        private readonly FabricaServicios _fabrica;
        private readonly Dictionary<string, Control> _controles;
        private Categoria _categoria = new();

        // categoriaId: null para crear; el Id de la categoría para editar.
        public FormCategoria(FabricaServicios fabrica, int? categoriaId)
        {
            _fabrica = fabrica;
            InitializeComponent();

            _controles = new Dictionary<string, Control>
            {
                [nameof(Categoria.Nombre)] = txtNombre,
                [nameof(Categoria.Descripcion)] = txtDescripcion,
                [nameof(Categoria.Fotos)] = btnAgregarFoto
            };

            if (categoriaId.HasValue)
            {
                Text = "Editar categoría";
                if (!CargarCategoria(categoriaId.Value)) Load += (_, _) => Close();
            }

            ActualizarContador();
        }

        protected override IReadOnlyDictionary<string, Control> ControlesPorCampo => _controles;

        private bool CargarCategoria(int id)
        {
            var resultado = _fabrica.Categorias.ObtenerPorId(id);
            if (Dialogos.HayError(resultado)) return false;

            _categoria = resultado.Valor!;
            txtNombre.Text = _categoria.Nombre;
            txtDescripcion.Text = _categoria.Descripcion;
            foreach (var foto in _categoria.Fotos) AgregarMiniatura(foto);
            return true;
        }

        protected override void Guardar()
        {
            LimpiarErrores();
            _categoria.Nombre = txtNombre.Text;
            _categoria.Descripcion = txtDescripcion.Text;

            if (_categoria.Id == 0) Procesar(_fabrica.Categorias.Crear(_categoria));
            else Procesar(_fabrica.Categorias.Actualizar(_categoria));
        }

        // Libera las imágenes de las miniaturas que siguen en pantalla.
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            foreach (var caja in panelFotos.Controls.OfType<Panel>().SelectMany(t => t.Controls.OfType<PictureBox>()))
                caja.Image?.Dispose();
            base.OnFormClosed(e);
        }

        // ---------------- Fotos ----------------

        private void btnAgregarFoto_Click(object? sender, EventArgs e)
        {
            if (_categoria.Fotos.Count >= Validador.MaximoFotos)
            {
                Dialogos.Info($"Una categoría admite máximo {Validador.MaximoFotos} fotos.");
                return;
            }

            using var dialogo = new OpenFileDialog
            {
                Title = "Seleccionar fotos",
                Filter = "Imágenes (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png",
                Multiselect = true
            };
            if (dialogo.ShowDialog(this) != DialogResult.OK) return;

            foreach (string ruta in dialogo.FileNames)
            {
                if (_categoria.Fotos.Count >= Validador.MaximoFotos)
                {
                    Dialogos.Info($"Solo se admiten {Validador.MaximoFotos} fotos por categoría.");
                    break;
                }

                try
                {
                    byte[] bytes = File.ReadAllBytes(ruta);
                    string nombre = Path.GetFileName(ruta);

                    string? error = Validador.ValidarFoto(nombre, bytes);
                    if (error != null)
                    {
                        Dialogos.Error(error);
                        continue;
                    }

                    var foto = new FotoCategoria { NombreArchivo = nombre, Imagen = bytes };
                    _categoria.Fotos.Add(foto);
                    AgregarMiniatura(foto);
                }
                catch (IOException ex)
                {
                    Dialogos.Error($"No se pudo leer el archivo: {ex.Message}");
                }
            }
            ActualizarContador();
        }

        // Las miniaturas dependen de los datos, por eso se crean en tiempo de ejecución.
        private void AgregarMiniatura(FotoCategoria foto)
        {
            var imagen = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.White,
                Image = CargarImagen(foto.Imagen)
            };
            var quitar = new Button
            {
                Text = "✕",
                Size = new Size(20, 20),
                Location = new Point(61, 2),
                FlatStyle = FlatStyle.Flat,
                BackColor = Tema.Peligro,
                ForeColor = Color.White,
                Font = FuenteQuitar,
                Cursor = Cursors.Hand
            };
            quitar.FlatAppearance.BorderSize = 0;

            var tile = new Panel
            {
                Size = new Size(84, 84),
                Margin = new Padding(0, 0, 8, 0),
                Padding = new Padding(1),
                BackColor = Tema.Borde
            };
            tile.Controls.Add(imagen);
            tile.Controls.Add(quitar);
            quitar.BringToFront();

            quitar.Click += (_, _) =>
            {
                _categoria.Fotos.Remove(foto);
                panelFotos.Controls.Remove(tile);
                imagen.Image?.Dispose();
                tile.Dispose();
                ActualizarContador();
            };

            panelFotos.Controls.Add(tile);
        }

        // Copia la imagen a un Bitmap independiente del stream.
        private static Image? CargarImagen(byte[] bytes)
        {
            try
            {
                using var stream = new MemoryStream(bytes);
                using var original = Image.FromStream(stream);
                return new Bitmap(original);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        private void ActualizarContador() =>
            lblFotos.Text = $"Fotos ({_categoria.Fotos.Count}/{Validador.MaximoFotos}) · .jpg, .jpeg o .png · máx. 2 MB";
    }
}
