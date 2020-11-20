using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayStationStore
{
    public partial class FrmPlayStation : Form
    {        
        protected PlayStation p;

        public PlayStation PlayStation
        {
            get { return this.p; }
        }

        public FrmPlayStation()
        {
            InitializeComponent();
        }

        public FrmPlayStation(PlayStation p) : this()
        {
            this.p = p;

            this.txtId.Text = this.p.Id.ToString();
            this.txtPrecio.Text = p.Precio.ToString();
            this.txtAlmacenamiento.Text = p.Almacenamiento.ToString();
            this.txtLanzamiento.Text = p.Lanzamiento;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string id = this.txtId.Text;
            id = id == "" ? "0" : id;

            this.p = new PlayStation(int.Parse(id), float.Parse(this.txtPrecio.Text), int.Parse(this.txtAlmacenamiento.Text), this.txtLanzamiento.Text, this.txtModelo.Text);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
