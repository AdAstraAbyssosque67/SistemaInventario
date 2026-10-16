using FontAwesome.Sharp;
using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio;
using SistemaInventario.LogicaNegocio.Validaciones;
using SistemaInventario.Presentacion.Estilos;
using SistemaInventario.Presentacion.Formulary;

namespace SistemaInventario.Presentacion.Formulary
{
    /// <summary>Formulario para crear o editar una categoría, con hasta 5 fotos.</summary>
    public class FormCategoria : FormularioEdicion
    {
        private readonly FabricaServicios _fabrica;
        private readonly Dictionary<string, Control> _controles;
        private Categoria _categoria = new();

        private readonly TextBox _txtNombre = new() { MaxLength = 100 };
        private readonly TextBox _txtDescripcion = new()
        {
            MaxLength = 500,
            Multiline = true,
            Height = 90,
            AcceptsReturn = true,
            ScrollBars = ScrollBars.Vertical
        };
        private readonly FlowLayoutPanel _panelFotos = new()
        {
            Height = 108,
            AutoScroll = true,
            WrapContents = false,
            Padding = new Padding(8),
            BackColor = Tema.Fondo
        };
        private readonly IconButton _btnAgregarFoto = Estilo.BotonSecundario("Agregar fotos", IconChar.Image, 150);
        private readonly Label _lblFotos;

        /// <param name="categoriaId">null para crear; el Id de la categoría para editar.</param>
        public FormCategoria(FabricaServicios fabrica, int? categoriaId)
            : base(categoriaId.HasValue ? "Editar categoría" : "Nueva categoría", new Size(560, 600))
        {
            _fabrica = fabrica;
            _controles = new Dictionary<string, Control>
            {
                [nameof(Categoria.Nombre)] = _txtNombre,
                [nameof(Categoria.Descripcion)] = _txtDescripcion,
                [nameof(Categoria.Fotos)] = _btnAgregarFoto
            };

            AgregarCampo("Nombre", _txtNombre);
            AgregarCampo("Descripción", _txtDescripcion);
            _lblFotos = AgregarCampo("Fotos", _panelFotos);
            AgregarControl(_btnAgregarFoto);
            _btnAgregarFoto.Click += (_, _) => AgregarFotos();

            if (categoriaId.HasValue && !CargarCategoria(categoriaId.Value))
                Load += (_, _) => Close();

            ActualizarContador();
        }

        protected override IReadOnlyDictionary<string, Control> ControlesPorCampo => _controles;

        private bool CargarCategoria(int id)
        {
            var resultado = _fabrica.Categorias.ObtenerPorId(id);
            if (!resultado.Exito)
            {
                Dialogos.Error(resultado.Mensaje);
                return false;
            }

            _categoria = resultado.Valor!;
            _txtNombre.Text = _categoria.Nombre;
            _txtDescripcion.Text = _categoria.Descripcion;
            foreach (var foto in _categoria.Fotos) AgregarMiniatura(foto);
            return true;
        }

        protected override void Guardar()
        {
            LimpiarErrores();
            _categoria.Nombre = _txtNombre.Text;
            _categoria.Descripcion = _txtDescripcion.Text;

            if (_categoria.Id == 0) Procesar(_fabrica.Categorias.Crear(_categoria));
            else Procesar(_fabrica.Categorias.Actualizar(_categoria));
        }

        // ---------------- Fotos ----------------

        private void AgregarFotos()
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
                Font = new Font("Segoe UI", 7F),
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
                _panelFotos.Controls.Remove(tile);
                imagen.Image?.Dispose();
                tile.Dispose();
                ActualizarContador();
            };

            _panelFotos.Controls.Add(tile);
        }

        /// <summary>Copia la imagen a un Bitmap independiente del stream.</summary>
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
            _lblFotos.Text = $"Fotos ({_categoria.Fotos.Count}/{Validador.MaximoFotos}) · .jpg, .jpeg o .png · máx. 2 MB";
    }
}