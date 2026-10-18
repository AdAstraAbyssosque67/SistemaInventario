namespace SistemaInventario.Presentacion.Formularios
{
    partial class FormProducto
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
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lblSuplidor = new System.Windows.Forms.Label();
            this.cmbSuplidor = new System.Windows.Forms.ComboBox();
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
            this.lblNombre.Text = "Nombre del producto";

            // txtNombre
            // 
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtNombre.MaxLength = 150;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(490, 27);
            this.txtNombre.TabIndex = 1;

            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.ForeColor = System.Drawing.Color.FromArgb(120, 134, 143);
            this.lblPrecio.Margin = new System.Windows.Forms.Padding(3, 14, 3, 4);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(150, 23);
            this.lblPrecio.TabIndex = 2;
            this.lblPrecio.Text = "Precio unitario (RD$)";

            // txtPrecio
            // 
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(490, 27);
            this.txtPrecio.TabIndex = 3;

            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(120, 134, 143);
            this.lblCategoria.Margin = new System.Windows.Forms.Padding(3, 14, 3, 4);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(150, 23);
            this.lblCategoria.TabIndex = 4;
            this.lblCategoria.Text = "Categoría";

            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(490, 29);
            this.cmbCategoria.TabIndex = 5;

            // lblSuplidor
            // 
            this.lblSuplidor.AutoSize = true;
            this.lblSuplidor.ForeColor = System.Drawing.Color.FromArgb(120, 134, 143);
            this.lblSuplidor.Margin = new System.Windows.Forms.Padding(3, 14, 3, 4);
            this.lblSuplidor.Name = "lblSuplidor";
            this.lblSuplidor.Size = new System.Drawing.Size(150, 23);
            this.lblSuplidor.TabIndex = 6;
            this.lblSuplidor.Text = "Suplidor";

            // cmbSuplidor
            // 
            this.cmbSuplidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSuplidor.FormattingEnabled = true;
            this.cmbSuplidor.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.cmbSuplidor.Name = "cmbSuplidor";
            this.cmbSuplidor.Size = new System.Drawing.Size(490, 29);
            this.cmbSuplidor.TabIndex = 7;

            // pnlCampos
            // 
            this.pnlCampos.AutoScroll = true;
            this.pnlCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCampos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlCampos.Name = "pnlCampos";
            this.pnlCampos.Padding = new System.Windows.Forms.Padding(24, 8, 24, 0);
            this.pnlCampos.Size = new System.Drawing.Size(560, 356);
            this.pnlCampos.TabIndex = 0;
            this.pnlCampos.WrapContents = false;
            this.pnlCampos.Controls.Add(this.lblNombre);
            this.pnlCampos.Controls.Add(this.txtNombre);
            this.pnlCampos.Controls.Add(this.lblPrecio);
            this.pnlCampos.Controls.Add(this.txtPrecio);
            this.pnlCampos.Controls.Add(this.lblCategoria);
            this.pnlCampos.Controls.Add(this.cmbCategoria);
            this.pnlCampos.Controls.Add(this.lblSuplidor);
            this.pnlCampos.Controls.Add(this.cmbSuplidor);

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

            // FormProducto
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(560, 420);
            this.Name = "FormProducto";
            this.Text = "Nuevo producto";
            this.Controls.Add(this.pnlCampos);
            this.Controls.Add(this.pnlPie);

            this.pnlCampos.ResumeLayout(false);
            this.pnlPie.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label lblSuplidor;
        private System.Windows.Forms.ComboBox cmbSuplidor;
        private System.Windows.Forms.FlowLayoutPanel pnlCampos;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private System.Windows.Forms.FlowLayoutPanel pnlPie;
    }
}
