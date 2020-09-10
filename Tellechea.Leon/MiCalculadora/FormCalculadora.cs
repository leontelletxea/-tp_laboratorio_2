using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            comboBox1.SelectedItem = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double numberOne, numberTwo, outcome;
            string selectedOperator;

            selectedOperator = comboBox1.Text;
            Numero Number1 = new Numero(textBox1.Text);
            Numero Number2 = new Numero(textBox2.Text);
            outcome = Calculadora.Operar(Number1, Number2, selectedOperator);

            label1.Text = outcome.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            label1.Text = "";
            comboBox1.SelectedItem = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Numero number = new Numero();
            label1.Text = number.DecimalBinario(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Numero number = new Numero();
            label1.Text = number.BinarioDecimal(textBox1.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
