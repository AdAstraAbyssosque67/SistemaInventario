namespace SistemaInventario.Presentacion.Vistas
{
    partial class VistaPapelera
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
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEliminado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid = new SistemaInventario.Presentacion.Controles.TablaListado();
            this.pnlTabla = new System.Windows.Forms.Panel();
            this.rbtnProductos = new SistemaInventario.Presentacion.Controles.BotonPestana();
            this.rbtnCategorias = new SistemaInventario.Presentacion.Controles.BotonPestana();
            this.rbtnSuplidores = new SistemaInventario.Presentacion.Controles.BotonPestana();
            this.flowSelector = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRestaurar = new FontAwesome.Sharp.IconButton();
            this.flowAcciones = new System.Windows.Forms.FlowLayoutPanel();
            this.campoBusqueda = new SistemaInventario.Presentacion.Controles.CampoBusqueda();
            this.pnlBarra = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.pnlTabla.SuspendLayout();
            this.flowSelector.SuspendLayout();
            this.flowAcciones.SuspendLayout();
            this.pnlBarra.SuspendLayout();
            this.SuspendLayout();

            // colNombre
            // 
            this.colNombre.DataPropertyName = "Nombre";
            this.colNombre.FillWeight = 30F;
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.MinimumWidth = 150;
            this.colNombre.Name = "colNombre";

            // colDetalle
            // 
            this.colDetalle.DataPropertyName = "Detalle";
            this.colDetalle.FillWeight = 45F;
            this.colDetalle.HeaderText = "Detalle";
            this.colDetalle.MinimumWidth = 200;
            this.colDetalle.Name = "colDetalle";

            // colEliminado
            // 
            dataGridViewCellStyle1.Format = "dd/MM/yyyy HH:mm";
            this.colEliminado.DefaultCellStyle = dataGridViewCellStyle1;
            this.colEliminado.DataPropertyName = "Eliminado";
            this.colEliminado.FillWeight = 25F;
            this.colEliminado.HeaderText = "Eliminado";
            this.colEliminado.MinimumWidth = 140;
            this.colEliminado.Name = "colEliminado";

            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Name = "grid";
            this.grid.TabIndex = 0;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colNombre, this.colDetalle, this.colEliminado });

            // pnlTabla
            // 
            this.pnlTabla.BackColor = System.Drawing.Color.FromArgb(226, 232, 238);
            this.pnlTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabla.Name = "pnlTabla";
            this.pnlTabla.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.pnlTabla.Size = new System.Drawing.Size(932, 560);
            this.pnlTabla.TabIndex = 2;
            this.pnlTabla.Controls.Add(this.grid);

            // rbtnProductos
            // 
            this.rbtnProductos.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.rbtnProductos.Name = "rbtnProductos";
            this.rbtnProductos.Size = new System.Drawing.Size(120, 38);
            this.rbtnProductos.TabIndex = 0;
            this.rbtnProductos.TabStop = true;
            this.rbtnProductos.Text = "Productos";
            this.rbtnProductos.CheckedChanged += new System.EventHandler(this.rbtnOrigen_CheckedChanged);

            // rbtnCategorias
            // 
            this.rbtnCategorias.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.rbtnCategorias.Name = "rbtnCategorias";
            this.rbtnCategorias.Size = new System.Drawing.Size(120, 38);
            this.rbtnCategorias.TabIndex = 1;
            this.rbtnCategorias.TabStop = true;
            this.rbtnCategorias.Text = "Categorías";
            this.rbtnCategorias.CheckedChanged += new System.EventHandler(this.rbtnOrigen_CheckedChanged);

            // rbtnSuplidores
            // 
            this.rbtnSuplidores.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.rbtnSuplidores.Name = "rbtnSuplidores";
            this.rbtnSuplidores.Size = new System.Drawing.Size(120, 38);
            this.rbtnSuplidores.TabIndex = 2;
            this.rbtnSuplidores.TabStop = true;
            this.rbtnSuplidores.Text = "Suplidores";
            this.rbtnSuplidores.CheckedChanged += new System.EventHandler(this.rbtnOrigen_CheckedChanged);

            // flowSelector
            // 
            this.flowSelector.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowSelector.Name = "flowSelector";
            this.flowSelector.Size = new System.Drawing.Size(932, 50);
            this.flowSelector.TabIndex = 1;
            this.flowSelector.WrapContents = false;
            this.flowSelector.Controls.Add(this.rbtnProductos);
            this.flowSelector.Controls.Add(this.rbtnCategorias);
            this.flowSelector.Controls.Add(this.rbtnSuplidores);

            // btnRestaurar
            // 
            this.btnRestaurar.BackColor = System.Drawing.Color.FromArgb(0, 177, 157);
            this.btnRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 177, 157);
            this.btnRestaurar.FlatAppearance.BorderSize = 1;
            this.btnRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurar.ForeColor = System.Drawing.Color.White;
            this.btnRestaurar.IconChar = FontAwesome.Sharp.IconChar.Undo;
            this.btnRestaurar.IconColor = System.Drawing.Color.White;
            this.btnRestaurar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRestaurar.IconSize = 18;
            this.btnRestaurar.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRestaurar.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(130, 38);
            this.btnRestaurar.TabIndex = 0;
            this.btnRestaurar.Text = " Restaurar";
            this.btnRestaurar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRestaurar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRestaurar.UseVisualStyleBackColor = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);

            // flowAcciones
            // 
            this.flowAcciones.AutoSize = true;
            this.flowAcciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowAcciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowAcciones.Name = "flowAcciones";
            this.flowAcciones.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.flowAcciones.Size = new System.Drawing.Size(120, 56);
            this.flowAcciones.TabIndex = 1;
            this.flowAcciones.WrapContents = false;
            this.flowAcciones.Controls.Add(this.btnRestaurar);

            // campoBusqueda
            // 
            this.campoBusqueda.Location = new System.Drawing.Point(0, 9);
            this.campoBusqueda.Name = "campoBusqueda";
            this.campoBusqueda.PlaceholderText = "Buscar en la papelera...";
            this.campoBusqueda.Size = new System.Drawing.Size(320, 38);
            this.campoBusqueda.TabIndex = 0;
            this.campoBusqueda.TextChanged += new System.EventHandler(this.campoBusqueda_TextChanged);

            // pnlBarra
            // 
            this.pnlBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarra.Name = "pnlBarra";
            this.pnlBarra.Size = new System.Drawing.Size(932, 56);
            this.pnlBarra.TabIndex = 0;
            this.pnlBarra.Controls.Add(this.flowAcciones);
            this.pnlBarra.Controls.Add(this.campoBusqueda);

            // VistaPapelera
            // 
            this.BackColor = System.Drawing.Color.FromArgb(246, 248, 251);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "VistaPapelera";
            this.Padding = new System.Windows.Forms.Padding(24, 24, 24, 24);
            this.Size = new System.Drawing.Size(980, 640);
            this.Controls.Add(this.pnlTabla);
            this.Controls.Add(this.flowSelector);
            this.Controls.Add(this.pnlBarra);

            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.pnlTabla.ResumeLayout(false);
            this.flowSelector.ResumeLayout(false);
            this.flowAcciones.ResumeLayout(false);
            this.flowAcciones.PerformLayout();
            this.pnlBarra.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEliminado;
        private SistemaInventario.Presentacion.Controles.TablaListado grid;
        private System.Windows.Forms.Panel pnlTabla;
        private SistemaInventario.Presentacion.Controles.BotonPestana rbtnProductos;
        private SistemaInventario.Presentacion.Controles.BotonPestana rbtnCategorias;
        private SistemaInventario.Presentacion.Controles.BotonPestana rbtnSuplidores;
        private System.Windows.Forms.FlowLayoutPanel flowSelector;
        private FontAwesome.Sharp.IconButton btnRestaurar;
        private System.Windows.Forms.FlowLayoutPanel flowAcciones;
        private SistemaInventario.Presentacion.Controles.CampoBusqueda campoBusqueda;
        private System.Windows.Forms.Panel pnlBarra;
    }
}
