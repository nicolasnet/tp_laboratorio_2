using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;


        #region Atributos

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;        

        #endregion


        #region Propiedades

        /// <summary>
        /// Obtener y setiar el atributo direccionEntrega de la clase.
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        /// <summary>
        /// Obtener y setiar el atributo estado de la clase.
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// Obtener y setiar el atributo trackingID de la clase.
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        #endregion


        #region Constructores

        /// <summary>
        /// Setea la direccionEntrega y el trackingID segun datos brindados.
        /// El estado se setea en "Ingresado".
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;
        }

        #endregion


        #region Metodos

        /// <summary>
        /// Genera el ciclo de vida del paquete, cambiando su estado.
        /// Al llegar al estado "Entregado" almacena el paquete en la base de datos.
        /// </summary>
        public void MockCicloDeVida()
        {
            
            while (true)
            {
                InformaEstado.Invoke(this, EventArgs.Empty);
                Thread.Sleep(10000);
                if (this.Estado == EEstado.Entregado)
                {
                    break;
                }
                this.Estado++;
            }

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch(Exception e)
            {
                throw e;
            }            
        }

        #endregion


        #region Sobrecargas

        /// <summary>
        /// Dos paquetes son iguales cuando poseen el mismo TrackingID.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return (p1.TrackingID == p2.TrackingID);
        }

        /// <summary>
        /// Dos paquetes son distintos cuando no poseen el mismo TrackingID.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return (p1.TrackingID != p2.TrackingID);
        }

        /// <summary>
        /// Retorna los datos en forma de estring del paquete.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        #endregion


        #region Interface Implementada

        /// <summary>
        /// Muestra los datos del paquete.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            StringBuilder info = new StringBuilder();

            info.AppendLine(string.Format("{0} para {1}\n", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega));

            return info.ToString();
        }

        #endregion


        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado,
        }

    }
}
