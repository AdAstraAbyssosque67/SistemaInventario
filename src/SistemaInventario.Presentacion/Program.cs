namespace SistemaInventario.Presentacion;

static class Program
{
    // 
    //  The main entry point for the application.
    // 
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        var fabrica = new SistemaInventario.LogicaNegocio.FabricaServicios(
            @"Server=(localdb)\MSSQLLocalDB;Database=SistemaInventario;Trusted_Connection=True;TrustServerCertificate=True;");
        Application.Run(new FormPrincipal(fabrica));

    }    
}