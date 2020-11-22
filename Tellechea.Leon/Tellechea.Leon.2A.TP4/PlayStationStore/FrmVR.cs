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
    public partial class FrmVR : Form
    {
        protected VR v;

        public VR VR
        {
            get { return this.v; }
        }

        public FrmVR()
        {
            InitializeComponent();
        }

        public FrmVR(VR v) : this()
        {
            this.v = v;

            this.txtId.Text = this.v.Id.ToString();
            this.txtPrecio.Text = v.Precio.ToString();
            this.cmbAlmacenamiento.Text = v.Almacenamiento.ToString();
            this.txtLanzamiento.Text = v.Lanzamiento;
            this.txtPeso.Text = v.Peso.ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string id = this.txtId.Text;
            id = id == "" ? "0" : id;

            FrmStore f = new FrmStore();

            try
            {
                this.v = new VR(int.Parse(id), float.Parse(this.txtPrecio.Text), f.ConvertirAEnum(this.cmbAlmacenamiento.Text), this.txtLanzamiento.Text, float.Parse(this.txtPeso.Text));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
