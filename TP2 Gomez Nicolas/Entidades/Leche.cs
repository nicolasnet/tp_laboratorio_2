using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Entidades_2017
{
    public class Leche : Producto
    {
        public enum ETipo { Entera, Descremada }
        private ETipo _tipo;


        #region Constructores

        /// <summary>
        /// Inicializar el objeto de tipo Leche.
        /// Por defecto, TIPO será ENTERA.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        /// 
        public Leche(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {
            this._tipo = ETipo.Entera;
        }


        /// <summary>
        /// Inicializar el objeto de tipo Leche.
        /// Por defecto, TIPO será ENTERA.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo) 
            : this (marca, codigo, color)
        {
            this._tipo = tipo;
        }

        #endregion


        #region Propiedades

        /// <summary>
        /// Las leches tienen 20 calorías.
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        #endregion


        #region Metodos

        // <summary>
        /// Publica todos los datos del Producto Leche.
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}\n", this.CantidadCalorias);
            sb.AppendFormat("TIPO : {0}\n", this._tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
