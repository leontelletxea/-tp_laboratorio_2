namespace PlayStationStore
{
    partial class FrmStore
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSincronizar = new System.Windows.Forms.Button();
            this.btnAgregarPs = new System.Windows.Forms.Button();
            this.btnAgregarVr = new System.Windows.Forms.Button();
            this.btnVender = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(542, 426);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnSincronizar
            // 
            this.btnSincronizar.Location = new System.Drawing.Point(639, 256);
            this.btnSincronizar.Name = "btnSincronizar";
            this.btnSincronizar.Size = new System.Drawing.Size(72, 42);
            this.btnSincronizar.TabIndex = 15;
            this.btnSincronizar.Text = "Sincronizar";
            this.btnSincronizar.UseVisualStyleBackColor = true;
            this.btnSincronizar.Click += new System.EventHandler(this.btnSincronizar_Click);
            // 
            // btnAgregarPs
            // 
            this.btnAgregarPs.Location = new System.Drawing.Point(568, 343);
            this.btnAgregarPs.Name = "btnAgregarPs";
            this.btnAgregarPs.Size = new System.Drawing.Size(98, 48);
            this.btnAgregarPs.TabIndex = 16;
            this.btnAgregarPs.Text = "Agregar PS";
            this.btnAgregarPs.UseVisualStyleBackColor = true;
            this.btnAgregarPs.Click += new System.EventHandler(this.btnAgregarPs_Click);
            // 
            // btnAgregarVr
            // 
            this.btnAgregarVr.Location = new System.Drawing.Point(688, 343);
            this.btnAgregarVr.Name = "btnAgregarVr";
            this.btnAgregarVr.Size = new System.Drawing.Size(95, 48);
            this.btnAgregarVr.TabIndex = 17;
            this.btnAgregarVr.Text = "Agregar VR";
            this.btnAgregarVr.UseVisualStyleBackColor = true;
            this.btnAgregarVr.Click += new System.EventHandler(this.btnAgregarVr_Click);
            // 
            // btnVender
            // 
            this.btnVender.Location = new System.Drawing.Point(568, 256);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(65, 42);
            this.btnVender.TabIndex = 18;
            this.btnVender.Text = "Vender";
            this.btnVender.UseVisualStyleBackColor = true;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(717, 256);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(66, 42);
            this.btnModificar.TabIndex = 19;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(573, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(208, 189);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // FrmStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnVender);
            this.Controls.Add(this.btnAgregarVr);
            this.Controls.Add(this.btnAgregarPs);
            this.Controls.Add(this.btnSincronizar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmStore";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSincronizar;
        private System.Windows.Forms.Button btnAgregarPs;
        private System.Windows.Forms.Button btnAgregarVr;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

