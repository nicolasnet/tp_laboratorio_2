using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Gomez_Nicolas
{
    public class Numero
    {
        #region Atributos

        private double numero;

        #endregion



        #region Propiedades

        /// <summary>
        /// Setea una variable del tipo string, 1ro la valida y la convierte el un double de ser posible, en el atributo de la Clase "Numero".
        /// </summary>
        private string SetNumero
        {            
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        #endregion



        #region Constructores

        /// <summary>
        /// En caso que no se desee inicializar el objeto en el momento de su creacion.
        /// </summary>
        public Numero()
        {

        }

        /// <summary>
        /// Inicializar el objeto con una variable del tipo double.
        /// </summary>
        /// <param name="numero"></param> Variable del tipo double a ser seteada.
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Inicializar el objeto con una variable del tipo string.
        /// </summary>
        /// <param name="strNumero"></param> Variable del tipo string que se valida para setear.
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;            
        }

        #endregion



        #region Metodos

        /// <summary>
        /// Comprobara que el valor recibido sea numerico.
        /// </summary>
        /// <param name="strNumero"></param> Numero en string.
        /// <returns></returns> El numero en formato double en caso de ser numerico. Sino retorna 0 (cero).
        private double ValidarNumero(string strNumero)
        {
            double aux = 0;

            if (double.TryParse(strNumero, out aux)) { }

            return aux;
        }
                

        /// <summary>
        /// Metodo que convierte un numero binario a un decimal entero.
        /// </summary>
        /// <param name="binario"></param> numero binario ingresado en tipo String.
        /// <returns></returns> Retorna un string con el numero si logro convertirlo o "Valor Invalido" si no pudo.
        public static string BinarioDecimal(string binario)
        {

            int i;
            int entero = 0;
            string respuesta = "";

            for (i = 0; i < binario.Length; i++)
            {   
                if(binario[i].ToString() == "1" || binario[i].ToString() == "0")
                {
                    entero = entero + (int.Parse(binario[i].ToString()) * (int)Math.Pow(2, binario.Length - (i + 1)));
                    respuesta = entero.ToString();
                }
                else
                {
                    respuesta = "Valor Invalido";
                    break;
                }                
            }
            return respuesta;
        }

        
        /// <summary>
        /// Metodo por el cual se convierte un numero decimal a uno binario.
        /// </summary>
        /// <param name="numero"></param> valor double brindado para convertir.
        /// <returns></returns> Retorna el numero binario convertido.
        public static string DecimalBinario(double numero)
        {
            string resultado = "";
                        
            if (numero != 0 && numero != 1)
            {
                resultado = resultado + Numero.DecimalBinario(numero / 2);
                resultado = resultado + (numero % 2);
            }
            else
            {
                resultado = resultado + numero;
            }

            return resultado;            
        }
        

        /// <summary>
        /// Metodo por el cual se convierte un numero decimal a uno binario.
        /// </summary>
        /// <param name="numeroStr"></param> valor string brindado para convertir.
        /// <returns></returns> Retorna un string con el numero si logro convertirlo o "Valor Invalido" si no pudo.
        public static string DecimalBinario(string numeroStr)
        {
            double numero;
            string resultado = "";

            if (double.TryParse(numeroStr, out numero) && numero >= 0)
            {
                if (numero != 0 && numero != 1)
                {
                    resultado = resultado + Numero.DecimalBinario(((int)numero / 2).ToString());
                    resultado = resultado + (numero % 2);
                }
                else
                {
                    resultado = resultado + numero;
                }
            }
            else
            {
                resultado = "Valor Invalido";
            }
            return resultado;
        }

        #endregion



        #region Sobrecarga Operadores

        /// <summary>
        /// Suma los atributos del objeto Numero.
        /// </summary>
        /// <param name="s1"></param> 1er objeto del tipo Numero.
        /// <param name="s2"></param> 2do objeto del tipo Numero.
        /// <returns></returns> Un double con la suma entre los atributos de los Objetos.
        public static double operator +(Numero s1, Numero s2)
        {
            double respuesta = 0;

            respuesta = s1.numero + s2.numero;

            return respuesta;
        }

        /// <summary>
        /// Resta los atributos del objeto Numero.
        /// </summary>
        /// <param name="s1"></param> 1er objeto del tipo Numero.
        /// <param name="s2"></param> 2do objeto del tipo Numero.
        /// <returns></returns> Un double con la resta entre los atributos de los Objetos.
        public static double operator -(Numero s1, Numero s2)
        {
            double respuesta = 0;

            respuesta = s1.numero - s2.numero;

            return respuesta;
        }

        /// <summary>
        /// Multiplica los atributos del objeto Numero.
        /// </summary>
        /// <param name="s1"></param> 1er objeto del tipo Numero.
        /// <param name="s2"></param> 2do objeto del tipo Numero.
        /// <returns></returns> Un double con el producto entre los atributos de los Objetos.
        public static double operator *(Numero s1, Numero s2)
        {
            double respuesta = 0;

            respuesta = s1.numero * s2.numero;

            return respuesta;
        }

        /// <summary>
        /// Divide los atributos del objeto Numero.
        /// </summary>
        /// <param name="s1"></param> Dividendo 1er objeto del tipo Numero.
        /// <param name="s2"></param> Divisor 2do objeto del tipo Numero.
        /// <returns></returns> Un double con el cociente entre los atributos de los Objetos.
        public static double operator /(Numero s1, Numero s2)
        {
            double respuesta = 0;

            respuesta = s1.numero / s2.numero;

            return respuesta;
        }


        /// <summary>
        /// Comparacion de igualacion entre los atributos de los objetos del tipo Numero.
        /// </summary>
        /// <param name="s1"></param> 1er objeto a comparar.
        /// <param name="s2"></param> 2do objeto a comparar
        /// <returns></returns> retorna true si los atributos son iguales. False si no lo son.
        public static bool operator == (Numero s1, Numero s2)
        {
            bool respuesta = false;

            if (s1.numero == s2.numero)
            {
                respuesta = true;
            }

            return respuesta;
        }


        /// <summary>
        /// Comparacion de desigualdad entre los atributos de los objetos del tipo Numero.
        /// </summary>
        /// <param name="s1"></param> 1er objeto a comparar.
        /// <param name="s2"></param> 2do objeto a comparar
        /// <returns></returns> retorna true si los atributos son distintos. False si no lo son.
        public static bool operator !=(Numero s1, Numero s2)
        {
            bool respuesta = false;

            if (s1.numero != s2.numero)
            {
                respuesta = true;
            }

            return respuesta;
        }


        /// <summary>
        /// Comparacion de igualdad entre el atributo del tipo double del objeto y un int.
        /// </summary>
        /// <param name="s1"></param> Objeto del tipo Numero.
        /// <param name="nro"></param> numero int.
        /// <returns></returns> retorna true si el atributo y el numero son iguales. False si no lo son.
        public static bool operator ==(Numero s1, int nro)
        {
            bool respuesta = false;

            if (s1.numero == nro)
            {
                respuesta = true;
            }

            return respuesta;
        }


        /// <summary>
        /// Comparacion de desigualdad entre el atributo del tipo double del objeto y un int.
        /// </summary>
        /// <param name="s1"></param> Objeto del tipo Numero.
        /// <param name="nro"></param> numero int.
        /// <returns></returns> retorna true si el atributo y el numero son distintos. False si no lo son.
        public static bool operator !=(Numero s1, int nro)
        {
            bool respuesta = false;

            if (s1.numero != nro)
            {
                respuesta = true;
            }

            return respuesta;
        }

        #endregion
    }
}
