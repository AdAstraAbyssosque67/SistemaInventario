namespace SistemaInventario.Presentacion.Vistas
{
    partial class VistaReportes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.colEtiqueta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid = new SistemaInventario.Presentacion.Controles.TablaListado();
            this.tarjetaDatos = new SistemaInventario.Presentacion.Controles.Tarjeta();
            this.grafico = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            this.tarjetaGrafico = new SistemaInventario.Presentacion.Controles.Tarjeta();
            this.tblContenido = new System.Windows.Forms.TableLayoutPanel();
            this.rbtnPorCategoria = new SistemaInventario.Presentacion.Controles.BotonPestana();
            this.rbtnTopSuplidores = new SistemaInventario.Presentacion.Controles.BotonPestana();
            this.rbtnPrecioPromedio = new SistemaInventario.Presentacion.Controles.BotonPestana();
            this.flowSelector = new System.Windows.Forms.FlowLayoutPanel();

            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.tarjetaDatos.SuspendLayout();
            this.tarjetaGrafico.SuspendLayout();
            this.tblContenido.SuspendLayout();
            this.flowSelector.SuspendLayout();
            this.SuspendLayout();

            // colEtiqueta
            // 
            this.colEtiqueta.DataPropertyName = "Etiqueta";
            this.colEtiqueta.FillWeight = 60F;
            this.colEtiqueta.HeaderText = "Etiqueta";
            this.colEtiqueta.MinimumWidth = 100;
            this.colEtiqueta.Name = "colEtiqueta";

            // colValor
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colValor.DefaultCellStyle = dataGridViewCellStyle1;
            this.colValor.DataPropertyName = "Valor";
            this.colValor.FillWeight = 40F;
            this.colValor.HeaderText = "Valor";
            this.colValor.MinimumWidth = 80;
            this.colValor.Name = "colValor";

            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Name = "grid";
            this.grid.TabIndex = 0;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colEtiqueta, this.colValor });

            // tarjetaDatos
            // 
            this.tarjetaDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tarjetaDatos.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tarjetaDatos.Name = "tarjetaDatos";
            this.tarjetaDatos.Size = new System.Drawing.Size(340, 500);
            this.tarjetaDatos.TabIndex = 0;
            this.tarjetaDatos.Titulo = "Datos";
            this.tarjetaDatos.Controls.Add(this.grid);

            // grafico
            // 
            this.grafico.BackColor = System.Drawing.Color.White;
            this.grafico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grafico.Name = "grafico";
            this.grafico.TabIndex = 0;

            // tarjetaGrafico
            // 
            this.tarjetaGrafico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tarjetaGrafico.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tarjetaGrafico.Name = "tarjetaGrafico";
            this.tarjetaGrafico.Size = new System.Drawing.Size(340, 500);
            this.tarjetaGrafico.TabIndex = 1;
            this.tarjetaGrafico.Titulo = "Gráfico";
            this.tarjetaGrafico.Controls.Add(this.grafico);

            // tblContenido
            // 
            this.tblContenido.ColumnCount = 2;
            this.tblContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblContenido.Name = "tblContenido";
            this.tblContenido.RowCount = 1;
            this.tblContenido.Size = new System.Drawing.Size(944, 520);
            this.tblContenido.TabIndex = 1;
            this.tblContenido.Controls.Add(this.tarjetaDatos, 0, 0);
            this.tblContenido.Controls.Add(this.tarjetaGrafico, 1, 0);
            this.tblContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tblContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62F));
            this.tblContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            // rbtnPorCategoria
            // 
            this.rbtnPorCategoria.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.rbtnPorCategoria.Name = "rbtnPorCategoria";
            this.rbtnPorCategoria.Size = new System.Drawing.Size(230, 38);
            this.rbtnPorCategoria.TabIndex = 0;
            this.rbtnPorCategoria.TabStop = true;
            this.rbtnPorCategoria.Text = "Productos por categoría";
            this.rbtnPorCategoria.CheckedChanged += new System.EventHandler(this.rbtnReporte_CheckedChanged);

            // rbtnTopSuplidores
            // 
            this.rbtnTopSuplidores.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.rbtnTopSuplidores.Name = "rbtnTopSuplidores";
            this.rbtnTopSuplidores.Size = new System.Drawing.Size(230, 38);
            this.rbtnTopSuplidores.TabIndex = 1;
            this.rbtnTopSuplidores.TabStop = true;
            this.rbtnTopSuplidores.Text = "Top 5 suplidores";
            this.rbtnTopSuplidores.CheckedChanged += new System.EventHandler(this.rbtnReporte_CheckedChanged);

            // rbtnPrecioPromedio
            // 
            this.rbtnPrecioPromedio.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.rbtnPrecioPromedio.Name = "rbtnPrecioPromedio";
            this.rbtnPrecioPromedio.Size = new System.Drawing.Size(230, 38);
            this.rbtnPrecioPromedio.TabIndex = 2;
            this.rbtnPrecioPromedio.TabStop = true;
            this.rbtnPrecioPromedio.Text = "Precio promedio por categoría";
            this.rbtnPrecioPromedio.CheckedChanged += new System.EventHandler(this.rbtnReporte_CheckedChanged);

            // flowSelector
            // 
            this.flowSelector.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowSelector.Name = "flowSelector";
            this.flowSelector.Padding = new System.Windows.Forms.Padding(6, 6, 0, 0);
            this.flowSelector.Size = new System.Drawing.Size(944, 54);
            this.flowSelector.TabIndex = 0;
            this.flowSelector.WrapContents = false;
            this.flowSelector.Controls.Add(this.rbtnPorCategoria);
            this.flowSelector.Controls.Add(this.rbtnTopSuplidores);
            this.flowSelector.Controls.Add(this.rbtnPrecioPromedio);

            // VistaReportes
            // 
            this.BackColor = System.Drawing.Color.FromArgb(246, 248, 251);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "VistaReportes";
            this.Padding = new System.Windows.Forms.Padding(18, 18, 18, 18);
            this.Size = new System.Drawing.Size(980, 640);
            this.Controls.Add(this.tblContenido);
            this.Controls.Add(this.flowSelector);

            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.tarjetaDatos.ResumeLayout(false);
            this.tarjetaGrafico.ResumeLayout(false);
            this.tblContenido.ResumeLayout(false);
            this.flowSelector.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn colEtiqueta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;
        private SistemaInventario.Presentacion.Controles.TablaListado grid;
        private SistemaInventario.Presentacion.Controles.Tarjeta tarjetaDatos;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart grafico;
        private SistemaInventario.Presentacion.Controles.Tarjeta tarjetaGrafico;
        private System.Windows.Forms.TableLayoutPanel tblContenido;
        private SistemaInventario.Presentacion.Controles.BotonPestana rbtnPorCategoria;
        private SistemaInventario.Presentacion.Controles.BotonPestana rbtnTopSuplidores;
        private SistemaInventario.Presentacion.Controles.BotonPestana rbtnPrecioPromedio;
        private System.Windows.Forms.FlowLayoutPanel flowSelector;
    }
}
