namespace SistemaInventario.Presentacion
{
    partial class FormPrincipal
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
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.lblTituloVista = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.pnlLineaBarra = new System.Windows.Forms.Panel();
            this.pnlBarraSuperior = new System.Windows.Forms.Panel();
            this.pnlDerecha = new System.Windows.Forms.Panel();
            this.btnInicio = new FontAwesome.Sharp.IconButton();
            this.btnProductos = new FontAwesome.Sharp.IconButton();
            this.btnCategorias = new FontAwesome.Sharp.IconButton();
            this.btnSuplidores = new FontAwesome.Sharp.IconButton();
            this.btnPapelera = new FontAwesome.Sharp.IconButton();
            this.btnReportes = new FontAwesome.Sharp.IconButton();
            this.flowMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.iconoLogo = new FontAwesome.Sharp.IconPictureBox();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.iconoLogo)).BeginInit();
            this.pnlBarraSuperior.SuspendLayout();
            this.pnlDerecha.SuspendLayout();
            this.flowMenu.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();

            // pnlContenido
            // 
            this.pnlContenido.BackColor = System.Drawing.Color.FromArgb(246, 248, 251);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(970, 696);
            this.pnlContenido.TabIndex = 0;

            // lblTituloVista
            // 
            this.lblTituloVista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTituloVista.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTituloVista.ForeColor = System.Drawing.Color.FromArgb(38, 50, 56);
            this.lblTituloVista.Name = "lblTituloVista";
            this.lblTituloVista.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.lblTituloVista.Size = new System.Drawing.Size(630, 64);
            this.lblTituloVista.TabIndex = 0;
            this.lblTituloVista.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblFecha
            // 
            this.lblFecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(120, 134, 143);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Padding = new System.Windows.Forms.Padding(0, 0, 24, 0);
            this.lblFecha.Size = new System.Drawing.Size(340, 64);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // pnlLineaBarra
            // 
            this.pnlLineaBarra.BackColor = System.Drawing.Color.FromArgb(226, 232, 238);
            this.pnlLineaBarra.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLineaBarra.Name = "pnlLineaBarra";
            this.pnlLineaBarra.Size = new System.Drawing.Size(970, 1);
            this.pnlLineaBarra.TabIndex = 2;

            // pnlBarraSuperior
            // 
            this.pnlBarraSuperior.BackColor = System.Drawing.Color.White;
            this.pnlBarraSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarraSuperior.Name = "pnlBarraSuperior";
            this.pnlBarraSuperior.Size = new System.Drawing.Size(970, 64);
            this.pnlBarraSuperior.TabIndex = 1;
            this.pnlBarraSuperior.Controls.Add(this.lblTituloVista);
            this.pnlBarraSuperior.Controls.Add(this.lblFecha);
            this.pnlBarraSuperior.Controls.Add(this.pnlLineaBarra);

            // pnlDerecha
            // 
            this.pnlDerecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDerecha.Name = "pnlDerecha";
            this.pnlDerecha.Size = new System.Drawing.Size(1010, 760);
            this.pnlDerecha.TabIndex = 0;
            this.pnlDerecha.Controls.Add(this.pnlContenido);
            this.pnlDerecha.Controls.Add(this.pnlBarraSuperior);

            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.FromArgb(0, 177, 157);
            this.btnInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 158, 140);
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInicio.ForeColor = System.Drawing.Color.White;
            this.btnInicio.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.btnInicio.IconColor = System.Drawing.Color.White;
            this.btnInicio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInicio.IconSize = 22;
            this.btnInicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnInicio.Size = new System.Drawing.Size(270, 48);
            this.btnInicio.TabIndex = 0;
            this.btnInicio.TabStop = false;
            this.btnInicio.Text = "   Inicio";
            this.btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnMenu_Click);

            // btnProductos
            // 
            this.btnProductos.BackColor = System.Drawing.Color.FromArgb(0, 177, 157);
            this.btnProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 158, 140);
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnProductos.ForeColor = System.Drawing.Color.White;
            this.btnProductos.IconChar = FontAwesome.Sharp.IconChar.Boxes;
            this.btnProductos.IconColor = System.Drawing.Color.White;
            this.btnProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProductos.IconSize = 22;
            this.btnProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnProductos.Size = new System.Drawing.Size(270, 48);
            this.btnProductos.TabIndex = 1;
            this.btnProductos.TabStop = false;
            this.btnProductos.Text = "   Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.Click += new System.EventHandler(this.btnMenu_Click);

            // btnCategorias
            // 
            this.btnCategorias.BackColor = System.Drawing.Color.FromArgb(0, 177, 157);
            this.btnCategorias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategorias.FlatAppearance.BorderSize = 0;
            this.btnCategorias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 158, 140);
            this.btnCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorias.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCategorias.ForeColor = System.Drawing.Color.White;
            this.btnCategorias.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.btnCategorias.IconColor = System.Drawing.Color.White;
            this.btnCategorias.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCategorias.IconSize = 22;
            this.btnCategorias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategorias.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnCategorias.Size = new System.Drawing.Size(270, 48);
            this.btnCategorias.TabIndex = 2;
            this.btnCategorias.TabStop = false;
            this.btnCategorias.Text = "   Categorías";
            this.btnCategorias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategorias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategorias.UseVisualStyleBackColor = false;
            this.btnCategorias.Click += new System.EventHandler(this.btnMenu_Click);

            // btnSuplidores
            // 
            this.btnSuplidores.BackColor = System.Drawing.Color.FromArgb(0, 177, 157);
            this.btnSuplidores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuplidores.FlatAppearance.BorderSize = 0;
            this.btnSuplidores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 158, 140);
            this.btnSuplidores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuplidores.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSuplidores.ForeColor = System.Drawing.Color.White;
            this.btnSuplidores.IconChar = FontAwesome.Sharp.IconChar.Truck;
            this.btnSuplidores.IconColor = System.Drawing.Color.White;
            this.btnSuplidores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSuplidores.IconSize = 22;
            this.btnSuplidores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuplidores.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnSuplidores.Name = "btnSuplidores";
            this.btnSuplidores.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnSuplidores.Size = new System.Drawing.Size(270, 48);
            this.btnSuplidores.TabIndex = 3;
            this.btnSuplidores.TabStop = false;
            this.btnSuplidores.Text = "   Suplidores";
            this.btnSuplidores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuplidores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSuplidores.UseVisualStyleBackColor = false;
            this.btnSuplidores.Click += new System.EventHandler(this.btnMenu_Click);

            // btnPapelera
            // 
            this.btnPapelera.BackColor = System.Drawing.Color.FromArgb(0, 177, 157);
            this.btnPapelera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPapelera.FlatAppearance.BorderSize = 0;
            this.btnPapelera.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 158, 140);
            this.btnPapelera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPapelera.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPapelera.ForeColor = System.Drawing.Color.White;
            this.btnPapelera.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnPapelera.IconColor = System.Drawing.Color.White;
            this.btnPapelera.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPapelera.IconSize = 22;
            this.btnPapelera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPapelera.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnPapelera.Name = "btnPapelera";
            this.btnPapelera.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnPapelera.Size = new System.Drawing.Size(270, 48);
            this.btnPapelera.TabIndex = 4;
            this.btnPapelera.TabStop = false;
            this.btnPapelera.Text = "   Papelera";
            this.btnPapelera.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPapelera.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPapelera.UseVisualStyleBackColor = false;
            this.btnPapelera.Click += new System.EventHandler(this.btnMenu_Click);

            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.FromArgb(0, 177, 157);
            this.btnReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 158, 140);
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnReportes.ForeColor = System.Drawing.Color.White;
            this.btnReportes.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            this.btnReportes.IconColor = System.Drawing.Color.White;
            this.btnReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReportes.IconSize = 22;
            this.btnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnReportes.Size = new System.Drawing.Size(270, 48);
            this.btnReportes.TabIndex = 5;
            this.btnReportes.TabStop = false;
            this.btnReportes.Text = "   Reportes";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.btnMenu_Click);

            // flowMenu
            // 
            this.flowMenu.BackColor = System.Drawing.Color.FromArgb(0, 177, 157);
            this.flowMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowMenu.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.flowMenu.Name = "flowMenu";
            this.flowMenu.Size = new System.Drawing.Size(270, 684);
            this.flowMenu.TabIndex = 0;
            this.flowMenu.WrapContents = false;
            this.flowMenu.Controls.Add(this.btnInicio);
            this.flowMenu.Controls.Add(this.btnProductos);
            this.flowMenu.Controls.Add(this.btnCategorias);
            this.flowMenu.Controls.Add(this.btnSuplidores);
            this.flowMenu.Controls.Add(this.btnPapelera);
            this.flowMenu.Controls.Add(this.btnReportes);

            // iconoLogo
            // 
            this.iconoLogo.BackColor = System.Drawing.Color.FromArgb(0, 177, 157);
            this.iconoLogo.IconChar = FontAwesome.Sharp.IconChar.Boxes;
            this.iconoLogo.IconColor = System.Drawing.Color.White;
            this.iconoLogo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconoLogo.IconSize = 34;
            this.iconoLogo.Location = new System.Drawing.Point(20, 19);
            this.iconoLogo.Name = "iconoLogo";
            this.iconoLogo.Size = new System.Drawing.Size(38, 38);
            this.iconoLogo.TabIndex = 0;
            this.iconoLogo.TabStop = false;

            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.BackColor = System.Drawing.Color.FromArgb(0, 177, 157);
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(64, 22);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(137, 28);
            this.lblLogo.TabIndex = 1;
            this.lblLogo.Text = "Invent-Engine";

            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(0, 177, 157);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(270, 76);
            this.pnlLogo.TabIndex = 1;
            this.pnlLogo.Controls.Add(this.iconoLogo);
            this.pnlLogo.Controls.Add(this.lblLogo);

            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(0, 177, 157);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(270, 760);
            this.pnlMenu.TabIndex = 1;
            this.pnlMenu.Controls.Add(this.flowMenu);
            this.pnlMenu.Controls.Add(this.pnlLogo);

            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(246, 248, 251);
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinimumSize = new System.Drawing.Size(1000, 640);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InventarioEngine";
            this.Controls.Add(this.pnlDerecha);
            this.Controls.Add(this.pnlMenu);
            this.Load += new System.EventHandler(this.FormPrincipal_Load);

            ((System.ComponentModel.ISupportInitialize)(this.iconoLogo)).EndInit();
            this.pnlBarraSuperior.ResumeLayout(false);
            this.pnlDerecha.ResumeLayout(false);
            this.flowMenu.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Label lblTituloVista;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Panel pnlLineaBarra;
        private System.Windows.Forms.Panel pnlBarraSuperior;
        private System.Windows.Forms.Panel pnlDerecha;
        private FontAwesome.Sharp.IconButton btnInicio;
        private FontAwesome.Sharp.IconButton btnProductos;
        private FontAwesome.Sharp.IconButton btnCategorias;
        private FontAwesome.Sharp.IconButton btnSuplidores;
        private FontAwesome.Sharp.IconButton btnPapelera;
        private FontAwesome.Sharp.IconButton btnReportes;
        private System.Windows.Forms.FlowLayoutPanel flowMenu;
        private FontAwesome.Sharp.IconPictureBox iconoLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Panel pnlMenu;
    }
}
