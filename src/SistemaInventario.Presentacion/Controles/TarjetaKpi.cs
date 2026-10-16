using FontAwesome.Sharp;
using SistemaInventario.Presentacion.Estilos;

namespace SistemaInventario.Presentacion.Controles
{
    // Tarjeta de indicador: ícono, título y una cifra grande.
    public class TarjetaKpi : Panel
    {
        private static readonly Font FuenteValor = new("Segoe UI Semibold", 15F);
        private readonly Label _valor = new();

        public TarjetaKpi(string titulo, IconChar icono)
        {
            Dock = DockStyle.Fill;
            Margin = new Padding(6);
            BackColor = Tema.Superficie;

            Controls.Add(new IconPictureBox
            {
                IconChar = icono,
                IconColor = Tema.Primario,
                IconSize = 32,
                BackColor = Tema.Superficie,
                Size = new Size(40, 40),
                Location = new Point(12, 28)
            });
            Controls.Add(new Label
            {
                Text = titulo,
                AutoSize = true,
                ForeColor = Tema.TextoSuave,
                BackColor = Tema.Superficie,
                Location = new Point(58, 22)
            });

            _valor.Text = "—";
            _valor.AutoSize = true;
            _valor.Font = FuenteValor;
            _valor.ForeColor = Tema.Texto;
            _valor.BackColor = Tema.Superficie;
            _valor.Location = new Point(56, 46);
            Controls.Add(_valor);

            Paint += (_, e) =>
            {
                using var lapiz = new Pen(Tema.Borde);
                e.Graphics.DrawRectangle(lapiz, 0, 0, Width - 1, Height - 1);
            };
        }

        // Cifra que se muestra en la tarjeta.
        public string Valor
        {
            get => _valor.Text;
            set => _valor.Text = value;
        }
    }
}