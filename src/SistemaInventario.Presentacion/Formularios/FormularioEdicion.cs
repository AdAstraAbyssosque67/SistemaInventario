using SistemaInventario.LogicaNegocio.Genericos;
using SistemaInventario.Presentacion.Estilos;

namespace SistemaInventario.Presentacion.Formularios
{
    // Base de los formularios de alta y edición: ErrorProvider y manejo de Resultado<T>.
    // Cada formulario derivado define sus campos y sus botones Guardar/Cancelar en su diseñador.
    // No es abstracta para que Visual Studio pueda abrir en modo Diseño los formularios derivados.
    public partial class FormularioEdicion : Form
    {
        public FormularioEdicion()
        {
            InitializeComponent();
        }

        // Lee los controles, llama al servicio y pasa el resultado a Procesar.
        protected virtual void Guardar()
        {
        }

        // Relaciona el nombre de cada campo (clave de error) con su control.
        protected virtual IReadOnlyDictionary<string, Control> ControlesPorCampo =>
            new Dictionary<string, Control>();

        protected void btnGuardar_Click(object? sender, EventArgs e) => Guardar();

        protected void LimpiarErrores() => errores.Clear();

        protected void MarcarError(Control control, string mensaje) => errores.SetError(control, mensaje);

        // Cierra con OK si hubo éxito; si no, marca cada campo con su error.
        protected void Procesar<T>(Resultado<T> resultado)
        {
            if (resultado.Exito)
            {
                DialogResult = DialogResult.OK;
                return;
            }

            bool marcado = false;
            foreach (var (campo, mensaje) in resultado.Errores)
            {
                if (ControlesPorCampo.TryGetValue(campo, out var control))
                {
                    errores.SetError(control, mensaje);
                    marcado = true;
                }
            }
            if (!marcado) Dialogos.Error(resultado.Mensaje);
        }
    }
}
