namespace SistemaInventario.Presentacion.Formularios
{
    partial class FormCategoria
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblFotos = new System.Windows.Forms.Label();
            this.panelFotos = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAgregarFoto = new FontAwesome.Sharp.IconButton();
            this.pnlCampos = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.pnlPie = new System.Windows.Forms.FlowLayoutPanel();

            this.pnlCampos.SuspendLayout();
            this.pnlPie.SuspendLayout();
            this.SuspendLayout();

            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(120, 134, 143);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(3, 14, 3, 4);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(150, 23);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";

            // txtNombre
            // 
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(490, 27);
            this.txtNombre.TabIndex = 1;

            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(120, 134, 143);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(3, 14, 3, 4);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(150, 23);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Descripción";

            // txtDescripcion
            // 
            this.txtDescripcion.AcceptsReturn = true;
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtDescripcion.MaxLength = 500;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(490, 90);
            this.txtDescripcion.TabIndex = 3;

            // lblFotos
            // 
            this.lblFotos.AutoSize = true;
            this.lblFotos.ForeColor = System.Drawing.Color.FromArgb(120, 134, 143);
            this.lblFotos.Margin = new System.Windows.Forms.Padding(3, 14, 3, 4);
            this.lblFotos.Name = "lblFotos";
            this.lblFotos.Size = new System.Drawing.Size(150, 23);
            this.lblFotos.TabIndex = 4;
            this.lblFotos.Text = "Fotos";

            // panelFotos
            // 
            this.panelFotos.AutoScroll = true;
            this.panelFotos.BackColor = System.Drawing.Color.FromArgb(246, 248, 251);
            this.panelFotos.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panelFotos.Name = "panelFotos";
            this.panelFotos.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.panelFotos.Size = new System.Drawing.Size(490, 108);
            this.panelFotos.TabIndex = 5;
            this.panelFotos.WrapContents = false;

            // btnAgregarFoto
            // 
            this.btnAgregarFoto.BackColor = System.Drawing.Color.White;
            this.btnAgregarFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarFoto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 232, 238);
            this.btnAgregarFoto.FlatAppearance.BorderSize = 1;
            this.btnAgregarFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarFoto.ForeColor = System.Drawing.Color.FromArgb(38, 50, 56);
            this.btnAgregarFoto.IconChar = FontAwesome.Sharp.IconChar.Image;
            this.btnAgregarFoto.IconColor = System.Drawing.Color.FromArgb(38, 50, 56);
            this.btnAgregarFoto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAgregarFoto.IconSize = 18;
            this.btnAgregarFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAgregarFoto.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.btnAgregarFoto.Name = "btnAgregarFoto";
            this.btnAgregarFoto.Size = new System.Drawing.Size(150, 38);
            this.btnAgregarFoto.TabIndex = 6;
            this.btnAgregarFoto.Text = " Agregar fotos";
            this.btnAgregarFoto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAgregarFoto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarFoto.UseVisualStyleBackColor = false;
            this.btnAgregarFoto.Click += new System.EventHandler(this.btnAgregarFoto_Click);

            // pnlCampos
            // 
            this.pnlCampos.AutoScroll = true;
            this.pnlCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCampos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlCampos.Name = "pnlCampos";
            this.pnlCampos.Padding = new System.Windows.Forms.Padding(24, 8, 24, 0);
            this.pnlCampos.Size = new System.Drawing.Size(560, 536);
            this.pnlCampos.TabIndex = 0;
            this.pnlCampos.WrapContents = false;
            this.pnlCampos.Controls.Add(this.lblNombre);
            this.pnlCampos.Controls.Add(this.txtNombre);
            this.pnlCampos.Controls.Add(this.lblDescripcion);
            this.pnlCampos.Controls.Add(this.txtDescripcion);
            this.pnlCampos.Controls.Add(this.lblFotos);
            this.pnlCampos.Controls.Add(this.panelFotos);
            this.pnlCampos.Controls.Add(this.btnAgregarFoto);

            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(0, 177, 157);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 177, 157);
            this.btnGuardar.FlatAppearance.BorderSize = 1;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnGuardar.IconColor = System.Drawing.Color.White;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 18;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 38);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 232, 238);
            this.btnCancelar.FlatAppearance.BorderSize = 1;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(38, 50, 56);
            this.btnCancelar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCancelar.IconColor = System.Drawing.Color.FromArgb(38, 50, 56);
            this.btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar.IconSize = 18;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 38);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            // pnlPie
            // 
            this.pnlPie.BackColor = System.Drawing.Color.FromArgb(246, 248, 251);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Padding = new System.Windows.Forms.Padding(24, 13, 24, 0);
            this.pnlPie.Size = new System.Drawing.Size(560, 64);
            this.pnlPie.TabIndex = 1;
            this.pnlPie.Controls.Add(this.btnGuardar);
            this.pnlPie.Controls.Add(this.btnCancelar);

            // FormCategoria
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(560, 600);
            this.Name = "FormCategoria";
            this.Text = "Nueva categoría";
            this.Controls.Add(this.pnlCampos);
            this.Controls.Add(this.pnlPie);

            this.pnlCampos.ResumeLayout(false);
            this.pnlPie.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblFotos;
        private System.Windows.Forms.FlowLayoutPanel panelFotos;
        private FontAwesome.Sharp.IconButton btnAgregarFoto;
        private System.Windows.Forms.FlowLayoutPanel pnlCampos;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private System.Windows.Forms.FlowLayoutPanel pnlPie;
    }
}
