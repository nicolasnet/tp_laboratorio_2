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
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
            this.Text = "Calculadora de Gomez Nicolas del curso 2ºC";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
        }



        #region Botones_Click

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }



        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (cmbOperador.Text == "+" || cmbOperador.Text == "-" || cmbOperador.Text == "*" || cmbOperador.Text == "/")
            {
                if (txtNumero2.Text == "0" && cmbOperador.Text == "/")
                {
                    lblResultado.Text = "No se puede \ndividir por cero";
                }
                else
                {
                    lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
                }
            }
            else
            {
                lblResultado.Text = "Ingresar\nOperador valido";
            }
            
        }



        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);              
        }


        
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
        }

        #endregion



        #region Metodos

        /// <summary>
        /// LLama a la funcion operar de la clase Calculadora que realiza una operacion matematica.
        /// </summary>
        /// <param name="numero1"></param> 1er numero de la operacion.
        /// <param name="numero2"></param> 2do numero de la operacion.
        /// <param name="operador"></param> tipo de operacion a realizar.
        /// <returns></returns> Un double con la solucion.
        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado = 0;

            Calculadora calculo = new Calculadora();
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
                        
            resultado = calculo.Operar(num1, num2, operador);
                
            return resultado;
        }



        /// <summary>
        /// Limpia el formulario para nuevas operaciones.
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
            lblResultado.Text = "";
        }

        #endregion
    }
}
