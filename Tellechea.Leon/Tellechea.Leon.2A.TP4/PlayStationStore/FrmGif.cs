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
    public partial class FrmGif : Form
    {
        public FrmGif()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.pictureBox1.Load("logo.gif");
            if (this.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Gracias por su compra!");
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
    }
}
