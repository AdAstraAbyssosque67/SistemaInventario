namespace SistemaInventario.Presentacion.Vistas
{
    partial class VistaProductos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSuplidor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid = new SistemaInventario.Presentacion.Controles.TablaListado();
            this.pnlTabla = new System.Windows.Forms.Panel();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.cmbSuplidor = new System.Windows.Forms.ComboBox();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.lblTotal = new System.Windows.Forms.Label();
            this.flowFiltros = new System.Windows.Forms.FlowLayoutPanel();
            this.btnEditar = new FontAwesome.Sharp.IconButton();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.btnNuevo = new FontAwesome.Sharp.IconButton();
            this.flowAcciones = new System.Windows.Forms.FlowLayoutPanel();
            this.campoBusqueda = new SistemaInventario.Presentacion.Controles.CampoBusqueda();
            this.pnlBarra = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.pnlTabla.SuspendLayout();
            this.flowFiltros.SuspendLayout();
            this.flowAcciones.SuspendLayout();
            this.pnlBarra.SuspendLayout();
            this.SuspendLayout();

            // colProducto
            // 
            this.colProducto.DataPropertyName = "Nombre";
            this.colProducto.FillWeight = 30F;
            this.colProducto.HeaderText = "Producto";
            this.colProducto.MinimumWidth = 150;
            this.colProducto.Name = "colProducto";

            // colCategoria
            // 
            this.colCategoria.DataPropertyName = "Categoria";
            this.colCategoria.FillWeight = 20F;
            this.colCategoria.HeaderText = "Categoría";
            this.colCategoria.MinimumWidth = 110;
            this.colCategoria.Name = "colCategoria";

            // colSuplidor
            // 
            this.colSuplidor.DataPropertyName = "Suplidor";
            this.colSuplidor.FillWeight = 22F;
            this.colSuplidor.HeaderText = "Suplidor";
            this.colSuplidor.MinimumWidth = 130;
            this.colSuplidor.Name = "colSuplidor";

            // colPrecio
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.colPrecio.DefaultCellStyle = dataGridViewCellStyle1;
            this.colPrecio.DataPropertyName = "Precio";
            this.colPrecio.FillWeight = 14F;
            this.colPrecio.HeaderText = "Precio (RD$)";
            this.colPrecio.MinimumWidth = 110;
            this.colPrecio.Name = "colPrecio";

            // colCreado
            // 
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.colCreado.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCreado.DataPropertyName = "FechaCreacion";
            this.colCreado.FillWeight = 14F;
            this.colCreado.HeaderText = "Creado";
            this.colCreado.MinimumWidth = 100;
            this.colCreado.Name = "colCreado";

            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Name = "grid";
            this.grid.TabIndex = 0;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colProducto, this.colCategoria, this.colSuplidor, this.colPrecio, this.colCreado });
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);

            // pnlTabla
            // 
            this.pnlTabla.BackColor = System.Drawing.Color.FromArgb(226, 232, 238);
            this.pnlTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabla.Name = "pnlTabla";
            this.pnlTabla.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.pnlTabla.Size = new System.Drawing.Size(932, 560);
            this.pnlTabla.TabIndex = 2;
            this.pnlTabla.Controls.Add(this.grid);

            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Margin = new System.Windows.Forms.Padding(0, 4, 12, 0);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(210, 29);
            this.cmbCategoria.TabIndex = 0;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.filtro_Changed);

            // cmbSuplidor
            // 
            this.cmbSuplidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSuplidor.FormattingEnabled = true;
            this.cmbSuplidor.Margin = new System.Windows.Forms.Padding(0, 4, 12, 0);
            this.cmbSuplidor.Name = "cmbSuplidor";
            this.cmbSuplidor.Size = new System.Drawing.Size(210, 29);
            this.cmbSuplidor.TabIndex = 1;
            this.cmbSuplidor.SelectedIndexChanged += new System.EventHandler(this.filtro_Changed);

            // txtMin
            // 
            this.txtMin.Margin = new System.Windows.Forms.Padding(0, 4, 12, 0);
            this.txtMin.Name = "txtMin";
            this.txtMin.PlaceholderText = "Precio mín.";
            this.txtMin.Size = new System.Drawing.Size(110, 27);
            this.txtMin.TabIndex = 2;
            this.txtMin.TextChanged += new System.EventHandler(this.filtro_Changed);

            // txtMax
            // 
            this.txtMax.Margin = new System.Windows.Forms.Padding(0, 4, 12, 0);
            this.txtMax.Name = "txtMax";
            this.txtMax.PlaceholderText = "Precio máx.";
            this.txtMax.Size = new System.Drawing.Size(110, 27);
            this.txtMax.TabIndex = 3;
            this.txtMax.TextChanged += new System.EventHandler(this.filtro_Changed);

            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.White;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 232, 238);
            this.btnLimpiar.FlatAppearance.BorderSize = 1;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(38, 50, 56);
            this.btnLimpiar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnLimpiar.IconColor = System.Drawing.Color.FromArgb(38, 50, 56);
            this.btnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiar.IconSize = 18;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(0, 3, 12, 0);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(90, 30);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(120, 134, 143);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 23);
            this.lblTotal.TabIndex = 5;

            // flowFiltros
            // 
            this.flowFiltros.AutoSize = true;
            this.flowFiltros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowFiltros.Name = "flowFiltros";
            this.flowFiltros.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.flowFiltros.Size = new System.Drawing.Size(932, 48);
            this.flowFiltros.TabIndex = 1;
            this.flowFiltros.Controls.Add(this.cmbCategoria);
            this.flowFiltros.Controls.Add(this.cmbSuplidor);
            this.flowFiltros.Controls.Add(this.txtMin);
            this.flowFiltros.Controls.Add(this.txtMax);
            this.flowFiltros.Controls.Add(this.btnLimpiar);
            this.flowFiltros.Controls.Add(this.lblTotal);

            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.White;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 232, 238);
            this.btnEditar.FlatAppearance.BorderSize = 1;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.ForeColor = System.Drawing.Color.FromArgb(38, 50, 56);
            this.btnEditar.IconChar = FontAwesome.Sharp.IconChar.Pen;
            this.btnEditar.IconColor = System.Drawing.Color.FromArgb(38, 50, 56);
            this.btnEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditar.IconSize = 18;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEditar.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(110, 38);
            this.btnEditar.TabIndex = 0;
            this.btnEditar.Text = " Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.White;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 232, 238);
            this.btnEliminar.FlatAppearance.BorderSize = 1;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(235, 87, 87);
            this.btnEliminar.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnEliminar.IconColor = System.Drawing.Color.FromArgb(235, 87, 87);
            this.btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar.IconSize = 18;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 38);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = " Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(0, 177, 157);
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 177, 157);
            this.btnNuevo.FlatAppearance.BorderSize = 1;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnNuevo.IconColor = System.Drawing.Color.White;
            this.btnNuevo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNuevo.IconSize = 18;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(110, 38);
            this.btnNuevo.TabIndex = 2;
            this.btnNuevo.Text = " Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            // flowAcciones
            // 
            this.flowAcciones.AutoSize = true;
            this.flowAcciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowAcciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowAcciones.Name = "flowAcciones";
            this.flowAcciones.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.flowAcciones.Size = new System.Drawing.Size(320, 56);
            this.flowAcciones.TabIndex = 1;
            this.flowAcciones.WrapContents = false;
            this.flowAcciones.Controls.Add(this.btnEditar);
            this.flowAcciones.Controls.Add(this.btnEliminar);
            this.flowAcciones.Controls.Add(this.btnNuevo);

            // campoBusqueda
            // 
            this.campoBusqueda.Location = new System.Drawing.Point(0, 9);
            this.campoBusqueda.Name = "campoBusqueda";
            this.campoBusqueda.PlaceholderText = "Buscar producto...";
            this.campoBusqueda.Size = new System.Drawing.Size(320, 38);
            this.campoBusqueda.TabIndex = 0;
            this.campoBusqueda.TextChanged += new System.EventHandler(this.filtro_Changed);

            // pnlBarra
            // 
            this.pnlBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarra.Name = "pnlBarra";
            this.pnlBarra.Size = new System.Drawing.Size(932, 56);
            this.pnlBarra.TabIndex = 0;
            this.pnlBarra.Controls.Add(this.flowAcciones);
            this.pnlBarra.Controls.Add(this.campoBusqueda);

            // VistaProductos
            // 
            this.BackColor = System.Drawing.Color.FromArgb(246, 248, 251);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "VistaProductos";
            this.Padding = new System.Windows.Forms.Padding(24, 24, 24, 24);
            this.Size = new System.Drawing.Size(980, 640);
            this.Controls.Add(this.pnlTabla);
            this.Controls.Add(this.flowFiltros);
            this.Controls.Add(this.pnlBarra);

            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.pnlTabla.ResumeLayout(false);
            this.flowFiltros.ResumeLayout(false);
            this.flowFiltros.PerformLayout();
            this.flowAcciones.ResumeLayout(false);
            this.flowAcciones.PerformLayout();
            this.pnlBarra.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSuplidor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreado;
        private SistemaInventario.Presentacion.Controles.TablaListado grid;
        private System.Windows.Forms.Panel pnlTabla;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.ComboBox cmbSuplidor;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TextBox txtMax;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.FlowLayoutPanel flowFiltros;
        private FontAwesome.Sharp.IconButton btnEditar;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnNuevo;
        private System.Windows.Forms.FlowLayoutPanel flowAcciones;
        private SistemaInventario.Presentacion.Controles.CampoBusqueda campoBusqueda;
        private System.Windows.Forms.Panel pnlBarra;
    }
}
