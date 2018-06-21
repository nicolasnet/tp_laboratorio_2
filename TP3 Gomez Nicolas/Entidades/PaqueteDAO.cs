using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        /// <summary>
        /// Insertar en base de datos el elemento del tipo paquete.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            try
            {
                return DAO.InsertaObjeto(string.Format("INSERT INTO dbo.Paquetes (direccionEntrega, trackingID, alumno) VALUES('{0}','{1}','Gomez Nicolas')", p.DireccionEntrega, p.TrackingID));
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
