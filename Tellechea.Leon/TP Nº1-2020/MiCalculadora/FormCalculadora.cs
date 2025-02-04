﻿using System;
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
            cmbOperador.SelectedItem = 0;
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            double outcome;

            Numero numberOne = new Numero(numero1);
            Numero numberTwo = new Numero(numero2);

            outcome = Calculadora.Operar(numberOne, numberTwo, operador);

            return outcome;
        }
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double outcome;
            string selectedOperator = cmbOperador.Text;
            string numberOne = txtNumero1.Text;
            string numberTwo = txtNumero2.Text;

            outcome = Operar(numberOne, numberTwo, selectedOperator);

            lblResultado.Text = outcome.ToString();
        }
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
            cmbOperador.Text = " ";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero number = new Numero();

            lblResultado.Text = number.DecimalBinario(lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero number = new Numero();

            lblResultado.Text = number.BinarioDecimal(lblResultado.Text);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
