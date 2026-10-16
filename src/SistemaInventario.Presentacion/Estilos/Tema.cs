namespace SistemaInventario.Presentacion.Estilos
{
    // Colores y fuentes de InventarioEngine (estilo verde-teal).
    public static class Tema
    {
        public static readonly Color Primario = Color.FromArgb(0, 177, 157);
        public static readonly Color PrimarioOscuro = Color.FromArgb(0, 140, 124);
        public static readonly Color PrimarioHover = Color.FromArgb(0, 158, 140);

        public static readonly Color Fondo = Color.FromArgb(246, 248, 251);
        public static readonly Color Superficie = Color.White;
        public static readonly Color Borde = Color.FromArgb(226, 232, 238);

        public static readonly Color Texto = Color.FromArgb(38, 50, 56);
        public static readonly Color TextoSuave = Color.FromArgb(120, 134, 143);
        public static readonly Color Peligro = Color.FromArgb(235, 87, 87);

        public static readonly Font FuenteBase = new("Segoe UI", 10F);
        public static readonly Font FuenteMenu = new("Segoe UI Semibold", 10.5F);
        public static readonly Font FuenteTitulo = new("Segoe UI Semibold", 16F);
        public static readonly Font FuenteLogo = new("Segoe UI Semibold", 15F);
    }
}