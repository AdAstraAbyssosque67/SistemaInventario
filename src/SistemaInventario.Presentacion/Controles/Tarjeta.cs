using System.ComponentModel;
using SistemaInventario.Presentacion.Estilos;

namespace SistemaInventario.Presentacion.Controles
{
    // Tarjeta blanca con borde y título. Los controles que se colocan dentro
    // ocupan el espacio que queda debajo del título.
    public class Tarjeta : Panel
    {
        private string _titulo = string.Empty;

        public Tarjeta()
        {
            BackColor = Tema.Superficie;
            Padding = new Padding(16, 42, 16, 12);
            ResizeRedraw = true;
        }

        [DefaultValue("")]
        public string Titulo
        {
            get => _titulo;
            set
            {
                _titulo = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            TextRenderer.DrawText(e.Graphics, _titulo, Tema.FuenteMenu, new Point(16, 12), Tema.Texto);
            using var lapiz = new Pen(Tema.Borde);
            e.Graphics.DrawRectangle(lapiz, 0, 0, Width - 1, Height - 1);
        }
    }
}
