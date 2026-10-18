using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using SistemaInventario.Presentacion.Estilos;

namespace SistemaInventario.Presentacion.Controles
{
    // Cuadro de búsqueda con borde fino y la misma altura que los botones (38 px).
    // Un TextBox normal no puede crecer en altura, por eso se aloja dentro de un contenedor.
    public class CampoBusqueda : Panel
    {
        private readonly TextBox _caja = new()
        {
            BorderStyle = BorderStyle.None,
            Dock = DockStyle.Fill
        };

        public CampoBusqueda()
        {
            Size = new Size(320, 38);
            BackColor = Tema.Borde;
            Padding = new Padding(1);

            var interior = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(10, 8, 10, 0)
            };
            interior.Controls.Add(_caja);
            interior.Click += (_, _) => _caja.Focus();
            Controls.Add(interior);

            _caja.TextChanged += (_, e) => OnTextChanged(e);
        }

        [DefaultValue("")]
        public string PlaceholderText
        {
            get => _caja.PlaceholderText;
            set => _caja.PlaceholderText = value;
        }

        [AllowNull]
        public override string Text
        {
            get => _caja.Text;
            set => _caja.Text = value ?? string.Empty;
        }
    }
}
