using System.ComponentModel;
using FontAwesome.Sharp;
using SistemaInventario.Presentacion.Estilos;

namespace SistemaInventario.Presentacion.Controles
{
    // Tarjeta de indicador: ícono, título y una cifra grande.
    public class TarjetaKpi : Panel
    {
        private readonly IconPictureBox _icono = new()
        {
            IconColor = Tema.Primario,
            IconSize = 32,
            BackColor = Tema.Superficie,
            Size = new Size(40, 40),
            Location = new Point(12, 28)
        };

        private readonly Label _titulo = new()
        {
            AutoSize = true,
            ForeColor = Tema.TextoSuave,
            BackColor = Tema.Superficie,
            Location = new Point(58, 22)
        };

        private readonly Label _valor = new()
        {
            Text = "—",
            AutoSize = true,
            Font = Tema.FuenteKpi,
            ForeColor = Tema.Texto,
            BackColor = Tema.Superficie,
            Location = new Point(56, 46)
        };

        public TarjetaKpi()
        {
            BackColor = Tema.Superficie;
            ResizeRedraw = true;
            Controls.AddRange(new Control[] { _icono, _titulo, _valor });
        }

        [DefaultValue(IconChar.None)]
        public IconChar Icono
        {
            get => _icono.IconChar;
            set => _icono.IconChar = value;
        }

        [DefaultValue("")]
        public string Titulo
        {
            get => _titulo.Text;
            set => _titulo.Text = value;
        }

        // Cifra que se muestra en la tarjeta.
        [DefaultValue("—")]
        public string Valor
        {
            get => _valor.Text;
            set => _valor.Text = value;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using var lapiz = new Pen(Tema.Borde);
            e.Graphics.DrawRectangle(lapiz, 0, 0, Width - 1, Height - 1);
        }
    }
}
