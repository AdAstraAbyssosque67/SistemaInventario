using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio;
using SistemaInventario.Presentacion.Estilos;

namespace SistemaInventario.Presentacion.Formularios
{
    // Formulario para crear o editar un suplidor.
    public partial class FormSuplidor : FormularioEdicion
    {
        private readonly FabricaServicios _fabrica;
        private readonly Dictionary<string, Control> _controles;
        private Suplidor _suplidor = new();

        // suplidorId: null para crear; el Id del suplidor para editar.
        public FormSuplidor(FabricaServicios fabrica, int? suplidorId)
        {
            _fabrica = fabrica;
            InitializeComponent();

            _controles = new Dictionary<string, Control>
            {
                [nameof(Suplidor.NombreEmpresa)] = txtEmpresa,
                [nameof(Suplidor.NombreContacto)] = txtContacto,
                [nameof(Suplidor.Telefono)] = txtTelefono,
                [nameof(Suplidor.Email)] = txtEmail,
                [nameof(Suplidor.SitioWeb)] = txtSitioWeb
            };

            if (!suplidorId.HasValue) return;

            Text = "Editar suplidor";
            if (!CargarSuplidor(suplidorId.Value)) Load += (_, _) => Close();
        }

        protected override IReadOnlyDictionary<string, Control> ControlesPorCampo => _controles;

        private bool CargarSuplidor(int id)
        {
            var resultado = _fabrica.Suplidores.ObtenerPorId(id);
            if (Dialogos.HayError(resultado)) return false;

            _suplidor = resultado.Valor!;
            txtEmpresa.Text = _suplidor.NombreEmpresa;
            txtContacto.Text = _suplidor.NombreContacto;
            txtTelefono.Text = _suplidor.Telefono;
            txtEmail.Text = _suplidor.Email;
            txtSitioWeb.Text = _suplidor.SitioWeb ?? string.Empty;
            return true;
        }

        protected override void Guardar()
        {
            LimpiarErrores();
            _suplidor.NombreEmpresa = txtEmpresa.Text;
            _suplidor.NombreContacto = txtContacto.Text;
            _suplidor.Telefono = txtTelefono.Text;
            _suplidor.Email = txtEmail.Text;
            _suplidor.SitioWeb = txtSitioWeb.Text;

            if (_suplidor.Id == 0) Procesar(_fabrica.Suplidores.Crear(_suplidor));
            else Procesar(_fabrica.Suplidores.Actualizar(_suplidor));
        }
    }
}
