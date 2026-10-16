using SistemaInventario.Presentacion.Estilos;

namespace SistemaInventario.Presentacion.Vistas
{
    /// <summary>Pantalla temporal mientras se construye la vista real.</summary>
    public class VistaPlaceholder : UserControl
    {
        public VistaPlaceholder(string titulo)
        {
            Dock = DockStyle.Fill;
            BackColor = Tema.Fondo;

            Controls.Add(new Label
            {
                Text = $"{titulo}\r\n(en construcción)",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = Tema.FuenteBase,
                ForeColor = Tema.TextoSuave
            });
        }
    }
}