namespace SistemaInventario.Presentacion.Vistas
{
    partial class VistaSuplidores
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
            this.colEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSitioWeb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid = new SistemaInventario.Presentacion.Controles.TablaListado();
            this.pnlTabla = new System.Windows.Forms.Panel();
            this.btnEditar = new FontAwesome.Sharp.IconButton();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.btnNuevo = new FontAwesome.Sharp.IconButton();
            this.flowAcciones = new System.Windows.Forms.FlowLayoutPanel();
            this.campoBusqueda = new SistemaInventario.Presentacion.Controles.CampoBusqueda();
            this.pnlBarra = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.pnlTabla.SuspendLayout();
            this.flowAcciones.SuspendLayout();
            this.pnlBarra.SuspendLayout();
            this.SuspendLayout();

            // colEmpresa
            // 
            this.colEmpresa.DataPropertyName = "NombreEmpresa";
            this.colEmpresa.FillWeight = 21F;
            this.colEmpresa.HeaderText = "Empresa";
            this.colEmpresa.MinimumWidth = 130;
            this.colEmpresa.Name = "colEmpresa";

            // colContacto
            // 
            this.colContacto.DataPropertyName = "NombreContacto";
            this.colContacto.FillWeight = 15F;
            this.colContacto.HeaderText = "Contacto";
            this.colContacto.MinimumWidth = 110;
            this.colContacto.Name = "colContacto";

            // colTelefono
            // 
            this.colTelefono.DataPropertyName = "Telefono";
            this.colTelefono.FillWeight = 12F;
            this.colTelefono.HeaderText = "Teléfono";
            this.colTelefono.MinimumWidth = 105;
            this.colTelefono.Name = "colTelefono";

            // colCorreo
            // 
            this.colCorreo.DataPropertyName = "Email";
            this.colCorreo.FillWeight = 28F;
            this.colCorreo.HeaderText = "Correo";
            this.colCorreo.MinimumWidth = 190;
            this.colCorreo.Name = "colCorreo";

            // colSitioWeb
            // 
            this.colSitioWeb.DataPropertyName = "SitioWeb";
            this.colSitioWeb.FillWeight = 24F;
            this.colSitioWeb.HeaderText = "Sitio web";
            this.colSitioWeb.MinimumWidth = 150;
            this.colSitioWeb.Name = "colSitioWeb";

            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Name = "grid";
            this.grid.TabIndex = 0;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colEmpresa, this.colContacto, this.colTelefono, this.colCorreo, this.colSitioWeb });
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);

            // pnlTabla
            // 
            this.pnlTabla.BackColor = System.Drawing.Color.FromArgb(226, 232, 238);
            this.pnlTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabla.Name = "pnlTabla";
            this.pnlTabla.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.pnlTabla.Size = new System.Drawing.Size(932, 560);
            this.pnlTabla.TabIndex = 1;
            this.pnlTabla.Controls.Add(this.grid);

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
            this.campoBusqueda.PlaceholderText = "Buscar suplidor...";
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

            // VistaSuplidores
            // 
            this.BackColor = System.Drawing.Color.FromArgb(246, 248, 251);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "VistaSuplidores";
            this.Padding = new System.Windows.Forms.Padding(24, 24, 24, 24);
            this.Size = new System.Drawing.Size(980, 640);
            this.Controls.Add(this.pnlTabla);
            this.Controls.Add(this.pnlBarra);

            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.pnlTabla.ResumeLayout(false);
            this.flowAcciones.ResumeLayout(false);
            this.flowAcciones.PerformLayout();
            this.pnlBarra.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSitioWeb;
        private SistemaInventario.Presentacion.Controles.TablaListado grid;
        private System.Windows.Forms.Panel pnlTabla;
        private FontAwesome.Sharp.IconButton btnEditar;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnNuevo;
        private System.Windows.Forms.FlowLayoutPanel flowAcciones;
        private SistemaInventario.Presentacion.Controles.CampoBusqueda campoBusqueda;
        private System.Windows.Forms.Panel pnlBarra;
    }
}
