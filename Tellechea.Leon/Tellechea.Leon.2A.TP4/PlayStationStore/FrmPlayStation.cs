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

        /// <summary>
        /// Completa los campos del form con la informacion de p
        /// </summary>
        /// <param name="p"></param>
        public FrmPlayStation(PlayStation p) : this()
        {
            this.p = p;

            this.txtId.Text = this.p.Id.ToString();
            this.txtPrecio.Text = p.Precio.ToString();
            this.cmbAlmacenamiento.Text = p.Almacenamiento.ToString();
            this.txtLanzamiento.Text = p.Lanzamiento;
            this.cmbModelo.Text = p.Modelo.ToString();
        }

        /// <summary>
        /// Crea un nuevo objeto de tipo PlayStation con la informacion del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string id = this.txtId.Text;
            id = id == "" ? "0" : id;

            FrmStore f = new FrmStore();

            try
            {
                this.p = new PlayStation(int.Parse(id), float.Parse(this.txtPrecio.Text), f.ConvertirAEnum(this.cmbAlmacenamiento.Text), this.txtLanzamiento.Text, int.Parse(this.cmbModelo.Text));
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
