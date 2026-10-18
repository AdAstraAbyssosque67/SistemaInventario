using SistemaInventario.Presentacion.Estilos;

namespace SistemaInventario.Presentacion.Controles
{
    // DataGridView con el estilo de la aplicación: sin bordes pesados, filas altas y selección suave.
    // Las columnas se definen en el diseñador de cada vista.
    public class TablaListado : DataGridView
    {
        private static readonly Color ColorEncabezado = Color.FromArgb(250, 251, 252);

        public TablaListado()
        {
            DoubleBuffered = true;
            BackgroundColor = Tema.Superficie;
            BorderStyle = BorderStyle.None;
            CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            GridColor = Tema.Borde;

            EnableHeadersVisualStyles = false;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            ColumnHeadersHeight = 44;
            ColumnHeadersDefaultCellStyle.BackColor = ColorEncabezado;
            ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorEncabezado;
            ColumnHeadersDefaultCellStyle.ForeColor = Tema.TextoSuave;
            ColumnHeadersDefaultCellStyle.SelectionForeColor = Tema.TextoSuave;
            ColumnHeadersDefaultCellStyle.Font = Tema.FuenteMenu;
            ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);

            DefaultCellStyle.Font = Tema.FuenteBase;
            DefaultCellStyle.ForeColor = Tema.Texto;
            DefaultCellStyle.SelectionBackColor = Color.FromArgb(222, 247, 243);
            DefaultCellStyle.SelectionForeColor = Tema.Texto;
            DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            DefaultCellStyle.NullValue = "—";
            RowTemplate.Height = 42;

            RowHeadersVisible = false;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeRows = false;
            ReadOnly = true;
            MultiSelect = false;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AutoGenerateColumns = false;
        }

        // El encabezado de una columna alineada a la derecha (cifras) se alinea igual.
        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            base.OnColumnAdded(e);
            var alineacion = e.Column.DefaultCellStyle.Alignment;
            if (alineacion == DataGridViewContentAlignment.MiddleRight)
                e.Column.HeaderCell.Style.Alignment = alineacion;
        }
    }
}
