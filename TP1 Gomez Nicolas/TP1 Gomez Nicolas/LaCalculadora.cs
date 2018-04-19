using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1_Gomez_Nicolas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Calculadora de Gomez Nicolas del curso 2ºC";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
        }      


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
            lblResultado.Text = "";
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnOperar_Click(object sender, EventArgs e)
        {
            Calculadora calculo = new Calculadora();
            Numero num1 = new Numero(txtNumero1.Text);
            Numero num2 = new Numero(txtNumero2.Text);

            if (cmbOperador.Text == "+" || cmbOperador.Text == "-" || cmbOperador.Text == "*" || cmbOperador.Text == "/")
            {
                if (txtNumero2.Text == "0" && cmbOperador.Text == "/")
                {
                    lblResultado.Text = "No se puede \ndividir por cero";
                }
                else
                {
                    lblResultado.Text = calculo.Operar(num1, num2, cmbOperador.Text).ToString();
                }
            }
            else
            {
                lblResultado.Text = "Ingresar\nOperador valido";
            }
        }


        private void ConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
        }


        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
        }
    }
}
