using SistemaInventario.Presentacion.Estilos;

namespace SistemaInventario.Presentacion.Controles
{
    // RadioButton con aspecto de botón; queda verde con letra blanca cuando está activo.
    public class BotonPestana : RadioButton
    {
        public BotonPestana()
        {
            Appearance = Appearance.Button;
            FlatStyle = FlatStyle.Flat;
            TextAlign = ContentAlignment.MiddleCenter;
            Size = new Size(120, 38);
            Margin = new Padding(0, 0, 8, 0);
            BackColor = Color.White;
            ForeColor = Tema.Texto;
            Cursor = Cursors.Hand;
            FlatAppearance.BorderColor = Tema.Borde;
            FlatAppearance.CheckedBackColor = Tema.Primario;
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            ForeColor = Checked ? Color.White : Tema.Texto;
            base.OnCheckedChanged(e);
        }
    }
}
