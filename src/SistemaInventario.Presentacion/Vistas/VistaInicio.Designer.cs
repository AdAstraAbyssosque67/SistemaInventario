namespace SistemaInventario.Presentacion.Vistas
{
    partial class VistaInicio
    {
        private System.ComponentModel.IContainer? components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.graficoCategorias = new LiveChartsCore.SkiaSharpView.WinForms.PieChart();
            this.tarjetaCategorias = new SistemaInventario.Presentacion.Controles.Tarjeta();
            this.graficoSuplidores = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            this.tarjetaSuplidores = new SistemaInventario.Presentacion.Controles.Tarjeta();
            this.graficoPrecios = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            this.tarjetaPrecios = new SistemaInventario.Presentacion.Controles.Tarjeta();
            this.tblGraficos = new System.Windows.Forms.TableLayoutPanel();
            this.kpiProductos = new SistemaInventario.Presentacion.Controles.TarjetaKpi();
            this.kpiCategorias = new SistemaInventario.Presentacion.Controles.TarjetaKpi();
            this.kpiSuplidores = new SistemaInventario.Presentacion.Controles.TarjetaKpi();
            this.kpiPrecio = new SistemaInventario.Presentacion.Controles.TarjetaKpi();
            this.kpiPapelera = new SistemaInventario.Presentacion.Controles.TarjetaKpi();
            this.tblKpis = new System.Windows.Forms.TableLayoutPanel();

            this.tarjetaCategorias.SuspendLayout();
            this.tarjetaSuplidores.SuspendLayout();
            this.tarjetaPrecios.SuspendLayout();
            this.tblGraficos.SuspendLayout();
            this.tblKpis.SuspendLayout();
            this.SuspendLayout();

            // graficoCategorias
            // 
            this.graficoCategorias.BackColor = System.Drawing.Color.White;
            this.graficoCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graficoCategorias.Name = "graficoCategorias";
            this.graficoCategorias.TabIndex = 0;

            // tarjetaCategorias
            // 
            this.tarjetaCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tarjetaCategorias.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tarjetaCategorias.Name = "tarjetaCategorias";
            this.tarjetaCategorias.Size = new System.Drawing.Size(360, 220);
            this.tarjetaCategorias.TabIndex = 0;
            this.tarjetaCategorias.Titulo = "Productos por categoría";
            this.tarjetaCategorias.Controls.Add(this.graficoCategorias);

            // graficoSuplidores
            // 
            this.graficoSuplidores.BackColor = System.Drawing.Color.White;
            this.graficoSuplidores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graficoSuplidores.Name = "graficoSuplidores";
            this.graficoSuplidores.TabIndex = 0;

            // tarjetaSuplidores
            // 
            this.tarjetaSuplidores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tarjetaSuplidores.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tarjetaSuplidores.Name = "tarjetaSuplidores";
            this.tarjetaSuplidores.Size = new System.Drawing.Size(360, 220);
            this.tarjetaSuplidores.TabIndex = 1;
            this.tarjetaSuplidores.Titulo = "Top 5 suplidores (cantidad de productos)";
            this.tarjetaSuplidores.Controls.Add(this.graficoSuplidores);

            // graficoPrecios
            // 
            this.graficoPrecios.BackColor = System.Drawing.Color.White;
            this.graficoPrecios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graficoPrecios.Name = "graficoPrecios";
            this.graficoPrecios.TabIndex = 0;

            // tarjetaPrecios
            // 
            this.tarjetaPrecios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tarjetaPrecios.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tarjetaPrecios.Name = "tarjetaPrecios";
            this.tarjetaPrecios.Size = new System.Drawing.Size(360, 220);
            this.tarjetaPrecios.TabIndex = 2;
            this.tarjetaPrecios.Titulo = "Precio promedio por categoría (RD$)";
            this.tarjetaPrecios.Controls.Add(this.graficoPrecios);

            // tblGraficos
            // 
            this.tblGraficos.ColumnCount = 2;
            this.tblGraficos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblGraficos.Name = "tblGraficos";
            this.tblGraficos.RowCount = 2;
            this.tblGraficos.Size = new System.Drawing.Size(944, 450);
            this.tblGraficos.TabIndex = 0;
            this.tblGraficos.Controls.Add(this.tarjetaCategorias, 0, 0);
            this.tblGraficos.Controls.Add(this.tarjetaSuplidores, 1, 0);
            this.tblGraficos.Controls.Add(this.tarjetaPrecios, 0, 1);
            this.tblGraficos.SetColumnSpan(this.tarjetaPrecios, 2);
            this.tblGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tblGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));

            // kpiProductos
            // 
            this.kpiProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpiProductos.Icono = FontAwesome.Sharp.IconChar.Boxes;
            this.kpiProductos.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.kpiProductos.Name = "kpiProductos";
            this.kpiProductos.Size = new System.Drawing.Size(180, 100);
            this.kpiProductos.TabIndex = 0;
            this.kpiProductos.Titulo = "Productos";

            // kpiCategorias
            // 
            this.kpiCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpiCategorias.Icono = FontAwesome.Sharp.IconChar.Tags;
            this.kpiCategorias.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.kpiCategorias.Name = "kpiCategorias";
            this.kpiCategorias.Size = new System.Drawing.Size(180, 100);
            this.kpiCategorias.TabIndex = 1;
            this.kpiCategorias.Titulo = "Categorías";

            // kpiSuplidores
            // 
            this.kpiSuplidores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpiSuplidores.Icono = FontAwesome.Sharp.IconChar.Truck;
            this.kpiSuplidores.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.kpiSuplidores.Name = "kpiSuplidores";
            this.kpiSuplidores.Size = new System.Drawing.Size(180, 100);
            this.kpiSuplidores.TabIndex = 2;
            this.kpiSuplidores.Titulo = "Suplidores";

            // kpiPrecio
            // 
            this.kpiPrecio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpiPrecio.Icono = FontAwesome.Sharp.IconChar.DollarSign;
            this.kpiPrecio.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.kpiPrecio.Name = "kpiPrecio";
            this.kpiPrecio.Size = new System.Drawing.Size(180, 100);
            this.kpiPrecio.TabIndex = 3;
            this.kpiPrecio.Titulo = "Precio promedio";

            // kpiPapelera
            // 
            this.kpiPapelera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpiPapelera.Icono = FontAwesome.Sharp.IconChar.Trash;
            this.kpiPapelera.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.kpiPapelera.Name = "kpiPapelera";
            this.kpiPapelera.Size = new System.Drawing.Size(180, 100);
            this.kpiPapelera.TabIndex = 4;
            this.kpiPapelera.Titulo = "En papelera";

            // tblKpis
            // 
            this.tblKpis.ColumnCount = 5;
            this.tblKpis.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblKpis.Name = "tblKpis";
            this.tblKpis.RowCount = 1;
            this.tblKpis.Size = new System.Drawing.Size(944, 112);
            this.tblKpis.TabIndex = 1;
            this.tblKpis.Controls.Add(this.kpiProductos, 0, 0);
            this.tblKpis.Controls.Add(this.kpiCategorias, 1, 0);
            this.tblKpis.Controls.Add(this.kpiSuplidores, 2, 0);
            this.tblKpis.Controls.Add(this.kpiPrecio, 3, 0);
            this.tblKpis.Controls.Add(this.kpiPapelera, 4, 0);
            this.tblKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblKpis.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            // VistaInicio
            // 
            this.BackColor = System.Drawing.Color.FromArgb(246, 248, 251);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "VistaInicio";
            this.Padding = new System.Windows.Forms.Padding(18, 18, 18, 18);
            this.Size = new System.Drawing.Size(980, 640);
            this.Controls.Add(this.tblGraficos);
            this.Controls.Add(this.tblKpis);

            this.tarjetaCategorias.ResumeLayout(false);
            this.tarjetaSuplidores.ResumeLayout(false);
            this.tarjetaPrecios.ResumeLayout(false);
            this.tblGraficos.ResumeLayout(false);
            this.tblKpis.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private LiveChartsCore.SkiaSharpView.WinForms.PieChart graficoCategorias;
        private SistemaInventario.Presentacion.Controles.Tarjeta tarjetaCategorias;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart graficoSuplidores;
        private SistemaInventario.Presentacion.Controles.Tarjeta tarjetaSuplidores;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart graficoPrecios;
        private SistemaInventario.Presentacion.Controles.Tarjeta tarjetaPrecios;
        private System.Windows.Forms.TableLayoutPanel tblGraficos;
        private SistemaInventario.Presentacion.Controles.TarjetaKpi kpiProductos;
        private SistemaInventario.Presentacion.Controles.TarjetaKpi kpiCategorias;
        private SistemaInventario.Presentacion.Controles.TarjetaKpi kpiSuplidores;
        private SistemaInventario.Presentacion.Controles.TarjetaKpi kpiPrecio;
        private SistemaInventario.Presentacion.Controles.TarjetaKpi kpiPapelera;
        private System.Windows.Forms.TableLayoutPanel tblKpis;
    }
}
