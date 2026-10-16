using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio;
using SistemaInventario.Presentacion.Estilos;
using SistemaInventario.Presentacion.Formulary;

namespace SistemaInventario.Presentacion.Formularios
{
    // Formulario para crear o editar un suplidor.
    public class FormSuplidor : FormularioEdicion
    {
        private readonly FabricaServicios _fabrica;
        private readonly Dictionary<string, Control> _controles;
        private Suplidor _suplidor = new();

        private readonly TextBox _txtEmpresa = new() { MaxLength = 150 };
        private readonly TextBox _txtContacto = new() { MaxLength = 100 };
        private readonly TextBox _txtTelefono = new() { MaxLength = 12, PlaceholderText = "809-555-0100" };
        private readonly TextBox _txtEmail = new() { MaxLength = 150, PlaceholderText = "contacto@empresa.com" };
        private readonly TextBox _txtSitioWeb = new() { MaxLength = 300, PlaceholderText = "https://www.empresa.com (opcional)" };

        // <param name="suplidorId">null para crear; el Id del suplidor para editar.</param>
        public FormSuplidor(FabricaServicios fabrica, int? suplidorId)
            : base(suplidorId.HasValue ? "Editar suplidor" : "Nuevo suplidor", new Size(560, 470))
        {
            _fabrica = fabrica;
            _controles = new Dictionary<string, Control>
            {
                [nameof(Suplidor.NombreEmpresa)] = _txtEmpresa,
                [nameof(Suplidor.NombreContacto)] = _txtContacto,
                [nameof(Suplidor.Telefono)] = _txtTelefono,
                [nameof(Suplidor.Email)] = _txtEmail,
                [nameof(Suplidor.SitioWeb)] = _txtSitioWeb
            };

            AgregarCampo("Nombre de la empresa", _txtEmpresa);
            AgregarCampo("Nombre del contacto", _txtContacto);
            AgregarCampo("Teléfono (809/829/849-XXX-XXXX)", _txtTelefono);
            AgregarCampo("Correo electrónico", _txtEmail);
            AgregarCampo("Sitio web", _txtSitioWeb);

            if (suplidorId.HasValue && !CargarSuplidor(suplidorId.Value))
                Load += (_, _) => Close();
        }

        protected override IReadOnlyDictionary<string, Control> ControlesPorCampo => _controles;

        private bool CargarSuplidor(int id)
        {
            var resultado = _fabrica.Suplidores.ObtenerPorId(id);
            if (!resultado.Exito)
            {
                Dialogos.Error(resultado.Mensaje);
                return false;
            }

            _suplidor = resultado.Valor!;
            _txtEmpresa.Text = _suplidor.NombreEmpresa;
            _txtContacto.Text = _suplidor.NombreContacto;
            _txtTelefono.Text = _suplidor.Telefono;
            _txtEmail.Text = _suplidor.Email;
            _txtSitioWeb.Text = _suplidor.SitioWeb ?? string.Empty;
            return true;
        }

        protected override void Guardar()
        {
            LimpiarErrores();
            _suplidor.NombreEmpresa = _txtEmpresa.Text;
            _suplidor.NombreContacto = _txtContacto.Text;
            _suplidor.Telefono = _txtTelefono.Text;
            _suplidor.Email = _txtEmail.Text;
            _suplidor.SitioWeb = _txtSitioWeb.Text;

            if (_suplidor.Id == 0) Procesar(_fabrica.Suplidores.Crear(_suplidor));
            else Procesar(_fabrica.Suplidores.Actualizar(_suplidor));
        }
    }
}