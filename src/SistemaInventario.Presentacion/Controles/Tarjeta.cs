using SistemaInventario.Presentacion.Estilos;

namespace SistemaInventario.Presentacion.Controles
{
    // Tarjeta blanca con borde y título que envuelve un control (gráfico, tabla...).
    public class Tarjeta : Panel
    {
        public Tarjeta(string titulo, Control contenido)
        {
            Dock = DockStyle.Fill;
            Margin = new Padding(6);
            Padding = new Padding(16, 12, 16, 12);
            BackColor = Tema.Superficie;

            contenido.Dock = DockStyle.Fill;
            Controls.Add(contenido);     // primero el que llena
            Controls.Add(new Label
            {
                Text = titulo,
                Dock = DockStyle.Top,
                Height = 30,
                Font = Tema.FuenteMenu,
                ForeColor = Tema.Texto,
                BackColor = Tema.Superficie
            });

            Paint += (_, e) =>
            {
                using var lapiz = new Pen(Tema.Borde);
                e.Graphics.DrawRectangle(lapiz, 0, 0, Width - 1, Height - 1);
            };
        }
    }
}