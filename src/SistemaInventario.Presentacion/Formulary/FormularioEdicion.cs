using FontAwesome.Sharp;
using SistemaInventario.LogicaNegocio.Genericos;
using SistemaInventario.Presentacion.Estilos;

namespace SistemaInventario.Presentacion.Formulary
{
    /// <summary>
    /// Base de los formularios de alta y edición: diseño, botones Guardar/Cancelar,
    /// ErrorProvider y manejo de Resultado&lt;T&gt;.
    /// </summary>
    public abstract class FormularioEdicion : Form
    {
        protected const int AnchoCampo = 490;

        private readonly ErrorProvider _errores = new() { BlinkStyle = ErrorBlinkStyle.NeverBlink };
        private readonly FlowLayoutPanel _cuerpo = new();

        protected FormularioEdicion(string titulo, Size tamanoCliente)
        {
            Text = titulo;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = tamanoCliente;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.White;
            Font = Tema.FuenteBase;
            _errores.ContainerControl = this;

            _cuerpo.Dock = DockStyle.Fill;
            _cuerpo.FlowDirection = FlowDirection.TopDown;
            _cuerpo.WrapContents = false;
            _cuerpo.AutoScroll = true;
            _cuerpo.Padding = new Padding(24, 8, 24, 0);

            var guardar = Estilo.BotonPrimario("Guardar", IconChar.None, 110);
            var cancelar = Estilo.BotonSecundario("Cancelar", IconChar.None, 110);
            cancelar.DialogResult = DialogResult.Cancel;
            guardar.Click += (_, _) => Guardar();

            var pie = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 64,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(24, 13, 24, 0),
                BackColor = Tema.Fondo
            };
            pie.Controls.Add(guardar);   // con RightToLeft, el primero queda a la derecha
            pie.Controls.Add(cancelar);

            Controls.Add(_cuerpo);       // primero el que llena, luego los acoplados al borde
            Controls.Add(pie);

            AcceptButton = guardar;
            CancelButton = cancelar;
        }

        /// <summary>Lee los controles, llama al servicio y pasa el resultado a Procesar.</summary>
        protected abstract void Guardar();

        /// <summary>Relaciona el nombre de cada campo (clave de error) con su control.</summary>
        protected abstract IReadOnlyDictionary<string, Control> ControlesPorCampo { get; }

        /// <summary>Agrega una etiqueta y su control. Devuelve la etiqueta por si se quiere cambiar su texto.</summary>
        protected Label AgregarCampo(string etiqueta, Control control)
        {
            var label = new Label
            {
                Text = etiqueta,
                AutoSize = true,
                ForeColor = Tema.TextoSuave,
                Margin = new Padding(3, 14, 3, 4)
            };
            control.Width = AnchoCampo;
            control.Margin = new Padding(3, 0, 3, 0);
            _cuerpo.Controls.Add(label);
            _cuerpo.Controls.Add(control);
            return label;
        }

        /// <summary>Agrega un control suelto (por ejemplo, un botón) debajo del último campo.</summary>
        protected void AgregarControl(Control control)
        {
            control.Margin = new Padding(3, 10, 3, 0);
            _cuerpo.Controls.Add(control);
        }

        protected void LimpiarErrores() => _errores.Clear();

        protected void MarcarError(Control control, string mensaje) => _errores.SetError(control, mensaje);

        /// <summary>Cierra con OK si hubo éxito; si no, marca cada campo con su error.</summary>
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
                    _errores.SetError(control, mensaje);
                    marcado = true;
                }
            }
            if (!marcado) Dialogos.Error(resultado.Mensaje);
        }
    }
}