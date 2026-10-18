namespace SistemaInventario.Presentacion.Formularios
{
    partial class FormSuplidor
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
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.lblContacto = new System.Windows.Forms.Label();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblSitioWeb = new System.Windows.Forms.Label();
            this.txtSitioWeb = new System.Windows.Forms.TextBox();
            this.pnlCampos = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.pnlPie = new System.Windows.Forms.FlowLayoutPanel();

            this.pnlCampos.SuspendLayout();
            this.pnlPie.SuspendLayout();
            this.SuspendLayout();

            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.ForeColor = System.Drawing.Color.FromArgb(120, 134, 143);
            this.lblEmpresa.Margin = new System.Windows.Forms.Padding(3, 14, 3, 4);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(150, 23);
            this.lblEmpresa.TabIndex = 0;
            this.lblEmpresa.Text = "Nombre de la empresa";

            // txtEmpresa
            // 
            this.txtEmpresa.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtEmpresa.MaxLength = 150;
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(490, 27);
            this.txtEmpresa.TabIndex = 1;

            // lblContacto
            // 
            this.lblContacto.AutoSize = true;
            this.lblContacto.ForeColor = System.Drawing.Color.FromArgb(120, 134, 143);
            this.lblContacto.Margin = new System.Windows.Forms.Padding(3, 14, 3, 4);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(150, 23);
            this.lblContacto.TabIndex = 2;
            this.lblContacto.Text = "Nombre del contacto";

            // txtContacto
            // 
            this.txtContacto.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtContacto.MaxLength = 100;
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(490, 27);
            this.txtContacto.TabIndex = 3;

            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(120, 134, 143);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(3, 14, 3, 4);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(150, 23);
            this.lblTelefono.TabIndex = 4;
            this.lblTelefono.Text = "Teléfono (809/829/849-XXX-XXXX)";

            // txtTelefono
            // 
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtTelefono.MaxLength = 12;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.PlaceholderText = "809-555-0100";
            this.txtTelefono.Size = new System.Drawing.Size(490, 27);
            this.txtTelefono.TabIndex = 5;

            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(120, 134, 143);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(3, 14, 3, 4);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(150, 23);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Correo electrónico";

            // txtEmail
            // 
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtEmail.MaxLength = 150;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "contacto@empresa.com";
            this.txtEmail.Size = new System.Drawing.Size(490, 27);
            this.txtEmail.TabIndex = 7;

            // lblSitioWeb
            // 
            this.lblSitioWeb.AutoSize = true;
            this.lblSitioWeb.ForeColor = System.Drawing.Color.FromArgb(120, 134, 143);
            this.lblSitioWeb.Margin = new System.Windows.Forms.Padding(3, 14, 3, 4);
            this.lblSitioWeb.Name = "lblSitioWeb";
            this.lblSitioWeb.Size = new System.Drawing.Size(150, 23);
            this.lblSitioWeb.TabIndex = 8;
            this.lblSitioWeb.Text = "Sitio web";

            // txtSitioWeb
            // 
            this.txtSitioWeb.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtSitioWeb.MaxLength = 300;
            this.txtSitioWeb.Name = "txtSitioWeb";
            this.txtSitioWeb.PlaceholderText = "https://www.empresa.com (opcional)";
            this.txtSitioWeb.Size = new System.Drawing.Size(490, 27);
            this.txtSitioWeb.TabIndex = 9;

            // pnlCampos
            // 
            this.pnlCampos.AutoScroll = true;
            this.pnlCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCampos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlCampos.Name = "pnlCampos";
            this.pnlCampos.Padding = new System.Windows.Forms.Padding(24, 8, 24, 0);
            this.pnlCampos.Size = new System.Drawing.Size(560, 406);
            this.pnlCampos.TabIndex = 0;
            this.pnlCampos.WrapContents = false;
            this.pnlCampos.Controls.Add(this.lblEmpresa);
            this.pnlCampos.Controls.Add(this.txtEmpresa);
            this.pnlCampos.Controls.Add(this.lblContacto);
            this.pnlCampos.Controls.Add(this.txtContacto);
            this.pnlCampos.Controls.Add(this.lblTelefono);
            this.pnlCampos.Controls.Add(this.txtTelefono);
            this.pnlCampos.Controls.Add(this.lblEmail);
            this.pnlCampos.Controls.Add(this.txtEmail);
            this.pnlCampos.Controls.Add(this.lblSitioWeb);
            this.pnlCampos.Controls.Add(this.txtSitioWeb);

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

            // FormSuplidor
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(560, 470);
            this.Name = "FormSuplidor";
            this.Text = "Nuevo suplidor";
            this.Controls.Add(this.pnlCampos);
            this.Controls.Add(this.pnlPie);

            this.pnlCampos.ResumeLayout(false);
            this.pnlPie.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.Label lblContacto;
        private System.Windows.Forms.TextBox txtContacto;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblSitioWeb;
        private System.Windows.Forms.TextBox txtSitioWeb;
        private System.Windows.Forms.FlowLayoutPanel pnlCampos;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private System.Windows.Forms.FlowLayoutPanel pnlPie;
    }
}
