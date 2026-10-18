using SistemaInventario.LogicaNegocio;

namespace SistemaInventario.Presentacion;

static class Program
{
    private const string CadenaConexion =
        @"Server=(localdb)\MSSQLLocalDB;Database=SistemaInventario;Trusted_Connection=True;TrustServerCertificate=True;";

    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new FormPrincipal(new FabricaServicios(CadenaConexion)));
    }
}
