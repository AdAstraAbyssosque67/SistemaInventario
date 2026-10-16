namespace SistemaInventario.Presentacion.Estilos
{
    /// <summary>Mensajes estándar de la aplicación.</summary>
    public static class Dialogos
    {
        private const string Titulo = "InventarioEngine";

        public static void Info(string mensaje) =>
            MessageBox.Show(mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void Error(string mensaje) =>
            MessageBox.Show(mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static bool Confirmar(string mensaje) =>
            MessageBox.Show(mensaje, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
    }
}