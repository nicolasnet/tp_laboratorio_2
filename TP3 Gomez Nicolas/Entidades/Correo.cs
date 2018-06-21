using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos

        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        #endregion


        #region Propiedades

        /// <summary>
        /// Obtener y setear el Atributo List<Paquete> paquetes.
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        #endregion


        #region Constructores

        /// <summary>
        /// Instancia los atributos paquetes y mockPaquetes.
        /// </summary>
        public Correo()
        {
            this.paquetes = new List<Paquete>();
            mockPaquetes = new List<Thread>();
        }

        #endregion


        #region Metodos

        /// <summary>
        /// Cierra los hilos en ejecución.
        /// </summary>
        public void FinEntregas()
        {            
            foreach(Thread t in this.mockPaquetes)
            {
                t.Abort();
            }
        }

        #endregion


        #region Sobrecargas

        /// <summary>
        /// Agrega un paquete al correo siempre y cuando no este repetido.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            try
            {
                bool aux = true;

                foreach (Paquete paq in c.Paquetes)
                {
                    if (paq == p)
                    {
                        aux = false;
                        break;
                    }
                }
                if (aux)
                {
                    c.Paquetes.Add(p);
                    Thread hilo = new Thread(p.MockCicloDeVida);
                    c.mockPaquetes.Add(hilo);
                    hilo.Start();
                }
                else
                {
                    throw new TrackinIdRepetidoException("El producto esta repetido, no se agregó");
                }
                
                return c;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion


        #region Interface Implementada

        /// <summary>
        /// Retorna en string los datos de todos los paquetes del correo.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            StringBuilder info = new StringBuilder();

            foreach(Paquete p in ((Correo)elemento).Paquetes)
            {
                info.AppendLine(string.Format("{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado.ToString()));
            }

            return info.ToString();            
        }

        #endregion
    }
}
