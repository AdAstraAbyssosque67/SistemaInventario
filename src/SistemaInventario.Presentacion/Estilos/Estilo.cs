using FontAwesome.Sharp;

namespace SistemaInventario.Presentacion.Estilos
{
    /// <summary>Métodos auxiliares que dan a los controles el estilo de la aplicación.</summary>
    public static class Estilo
    {
        public static IconButton BotonPrimario(string texto, IconChar icono, int ancho = 120) =>
            CrearBoton(texto, icono, Tema.Primario, Color.White, Tema.Primario, ancho);

        public static IconButton BotonSecundario(string texto, IconChar icono, int ancho = 120) =>
            CrearBoton(texto, icono, Color.White, Tema.Texto, Tema.Borde, ancho);

        public static IconButton BotonPeligro(string texto, IconChar icono, int ancho = 120) =>
            CrearBoton(texto, icono, Color.White, Tema.Peligro, Tema.Borde, ancho);

        private static IconButton CrearBoton(string texto, IconChar icono, Color fondo,
                                             Color letra, Color borde, int ancho)
        {
            var boton = new IconButton
            {
                Text = icono == IconChar.None ? texto : " " + texto,
                IconChar = icono,
                IconColor = letra,
                IconSize = 18,
                Size = new Size(ancho, 38),
                Margin = new Padding(8, 0, 0, 0),
                FlatStyle = FlatStyle.Flat,
                BackColor = fondo,
                ForeColor = letra,
                Font = Tema.FuenteBase,
                TextAlign = ContentAlignment.MiddleCenter,
                ImageAlign = ContentAlignment.MiddleCenter,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                Cursor = Cursors.Hand
            };
            boton.FlatAppearance.BorderSize = 1;
            boton.FlatAppearance.BorderColor = borde;
            return boton;
        }

        /// <summary>Estilo limpio para los listados (sin bordes pesados, filas altas, selección suave).</summary>
        public static void AplicarTabla(DataGridView grid)
        {
            grid.Dock = DockStyle.Fill;
            grid.BackgroundColor = Tema.Superficie;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Tema.Borde;

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersHeight = 44;
            var encabezado = Color.FromArgb(250, 251, 252);
            grid.ColumnHeadersDefaultCellStyle.BackColor = encabezado;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = encabezado;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Tema.TextoSuave;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Tema.TextoSuave;
            grid.ColumnHeadersDefaultCellStyle.Font = Tema.FuenteMenu;
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);

            grid.DefaultCellStyle.Font = Tema.FuenteBase;
            grid.DefaultCellStyle.ForeColor = Tema.Texto;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(222, 247, 243);
            grid.DefaultCellStyle.SelectionForeColor = Tema.Texto;
            grid.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            grid.RowTemplate.Height = 42;

            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.ReadOnly = true;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.AutoGenerateColumns = false;
        }

        /// <summary>Crea una columna de texto enlazada a una propiedad. El peso reparte el ancho.</summary>
        public static DataGridViewTextBoxColumn Columna(string encabezado, string propiedad,
                                                        float peso, string? formato = null)
        {
            var columna = new DataGridViewTextBoxColumn
            {
                HeaderText = encabezado,
                DataPropertyName = propiedad,
                FillWeight = peso
            };
            columna.DefaultCellStyle.NullValue = "—";
            if (formato != null) columna.DefaultCellStyle.Format = formato;
            return columna;
        }
    }
}