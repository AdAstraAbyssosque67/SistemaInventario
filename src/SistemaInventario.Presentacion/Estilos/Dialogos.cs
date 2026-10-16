using SistemaInventario.LogicaNegocio.Genericos;

namespace SistemaInventario.Presentacion.Estilos
{
    // Mensajes estándar de la aplicación.
    public static class Dialogos
    {
        private const string Titulo = "InventarioEngine";

        public static void Info(string mensaje) =>
            MessageBox.Show(mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void Error(string mensaje) =>
            MessageBox.Show(mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static bool Confirmar(string mensaje) =>
            MessageBox.Show(mensaje, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        // Muestra el mensaje si el resultado falló. Devuelve true cuando hubo error.
        public static bool HayError<T>(Resultado<T> resultado)
        {
            if (resultado.Exito) return false;
            Error(resultado.Mensaje);
            return true;
        }
    }
}