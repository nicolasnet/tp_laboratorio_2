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

namespace MainCorreo
{
    public partial class Form1 : Form
    {
        Correo correoGomez;

        /// <summary>
        /// Constructor del formulario. Intancio el correoGomez.
        /// Edito algunas detalles del formulario.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            //Titulo del formulario.
            this.Text = "Correo UTN por Nicolas.Gomez.2ºC";
                                  
            //Eliminar boton de maximizado.
            this.MaximizeBox = false;

            //Eliminar boton de minimizado.
            this.MinimizeBox = false;

            //Bloquear que el usuario modifique el tamaño del formulario.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //Cargar el formulario en el centro de la pantalla.
            this.StartPosition = FormStartPosition.CenterScreen;

            correoGomez = new Correo();
        }

        #region Enventos

        /// <summary>
        /// Con este boton agregamos un paquete a la lista del correo y actualizamos los listBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
                       
            
            try
            {
                p.InformaEstado += paq_InformaEstado;
                this.correoGomez += p;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ActualizarEstados();
        }
    

        /// <summary>
        /// Mostrar todos los paquetes del correo en el richTextBox (abajo a la izquierda en el formulario).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correoGomez);
        }


        /// <summary>
        /// Con click derecho en el listBox de Entregados
        /// podra usarse "Mostrar" para ver el paquete seleccionado en el richTextBox (abajo a la izquierda en el formulario).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }


        /// <summary>
        /// Al cerrar el formulario se llama al metodo FinEntregas para cerrar todos los hilos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.correoGomez.FinEntregas();
        }

        #endregion


        #region Metodos
        
        /// <summary>
        /// Llama al metodo ActualizarEstados en un hilo diferente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }


        /// <summary>
        /// Limpia los 3 listBox del formulario
        /// Recorre la lista de paquetes del correo para agregarlos al listBox que corresponde
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoEntregado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoIngresado.Items.Clear();

            foreach(Paquete p in this.correoGomez.Paquetes)
            {
                switch (p.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(p);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(p);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(p);
                        break;
                }
            }
        }


        /// <summary>
        /// Muestra la informacion de los elementos en el richTextBox del formulario (abajo a la izquierda).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if(elemento != null)
            {
                rtbMostar.Text = elemento.MostrarDatos(elemento);
                elemento.MostrarDatos(elemento).Guardar("salida");
            }
        }

        #endregion

    }
}
