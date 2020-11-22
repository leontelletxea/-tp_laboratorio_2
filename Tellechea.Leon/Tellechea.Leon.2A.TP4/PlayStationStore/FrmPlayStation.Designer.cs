namespace PlayStationStore
{
    partial class FrmPlayStation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLanzamiento = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblLanzamiento = new System.Windows.Forms.Label();
            this.lblAlmacenamiento = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblModelo = new System.Windows.Forms.Label();
            this.cmbModelo = new System.Windows.Forms.ComboBox();
            this.cmbAlmacenamiento = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtLanzamiento
            // 
            this.txtLanzamiento.Location = new System.Drawing.Point(49, 201);
            this.txtLanzamiento.Name = "txtLanzamiento";
            this.txtLanzamiento.Size = new System.Drawing.Size(216, 20);
            this.txtLanzamiento.TabIndex = 29;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(49, 104);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(216, 20);
            this.txtPrecio.TabIndex = 27;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(49, 59);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(216, 20);
            this.txtId.TabIndex = 26;
            // 
            // lblLanzamiento
            // 
            this.lblLanzamiento.AutoSize = true;
            this.lblLanzamiento.Location = new System.Drawing.Point(46, 185);
            this.lblLanzamiento.Name = "lblLanzamiento";
            this.lblLanzamiento.Size = new System.Drawing.Size(67, 13);
            this.lblLanzamiento.TabIndex = 25;
            this.lblLanzamiento.Text = "Lanzamiento";
            // 
            // lblAlmacenamiento
            // 
            this.lblAlmacenamiento.AutoSize = true;
            this.lblAlmacenamiento.Location = new System.Drawing.Point(46, 135);
            this.lblAlmacenamiento.Name = "lblAlmacenamiento";
            this.lblAlmacenamiento.Size = new System.Drawing.Size(85, 13);
            this.lblAlmacenamiento.TabIndex = 24;
            this.lblAlmacenamiento.Text = "Almacenamiento";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(46, 88);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(37, 13);
            this.lblPrecio.TabIndex = 23;
            this.lblPrecio.Text = "Precio";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(46, 43);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 13);
            this.lblId.TabIndex = 22;
            this.lblId.Text = "Id";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(190, 287);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(49, 287);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 20;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Location = new System.Drawing.Point(46, 232);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(42, 13);
            this.lblModelo.TabIndex = 30;
            this.lblModelo.Text = "Modelo";
            // 
            // cmbModelo
            // 
            this.cmbModelo.FormattingEnabled = true;
            this.cmbModelo.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbModelo.Location = new System.Drawing.Point(49, 248);
            this.cmbModelo.Name = "cmbModelo";
            this.cmbModelo.Size = new System.Drawing.Size(216, 21);
            this.cmbModelo.TabIndex = 32;
            this.cmbModelo.SelectedIndex = 4;
            // 
            // cmbAlmacenamiento
            // 
            this.cmbAlmacenamiento.FormattingEnabled = true;
            this.cmbAlmacenamiento.Items.AddRange(new object[] {
            "MB1",
            "MB8",
            "GB250",
            "GB500",
            "TB1"});
            this.cmbAlmacenamiento.Location = new System.Drawing.Point(49, 151);
            this.cmbAlmacenamiento.Name = "cmbAlmacenamiento";
            this.cmbAlmacenamiento.Size = new System.Drawing.Size(216, 21);
            this.cmbAlmacenamiento.TabIndex = 33;
            this.cmbAlmacenamiento.SelectedIndex = 4;
            // 
            // FrmPlayStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 353);
            this.Controls.Add(this.cmbAlmacenamiento);
            this.Controls.Add(this.cmbModelo);
            this.Controls.Add(this.lblModelo);
            this.Controls.Add(this.txtLanzamiento);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblLanzamiento);
            this.Controls.Add(this.lblAlmacenamiento);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Name = "FrmPlayStation";
            this.Text = "FrmSony";
            this.Click += new System.EventHandler(this.btnAceptar_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLanzamiento;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblLanzamiento;
        private System.Windows.Forms.Label lblAlmacenamiento;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.ComboBox cmbModelo;
        private System.Windows.Forms.ComboBox cmbAlmacenamiento;
    }
}