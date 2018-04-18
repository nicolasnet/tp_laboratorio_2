using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Gomez_Nicolas
{
    public class Calculadora
    {
        private static string ValidarOperador(string operador)
        {
            string respuesta = "+";

            if(operador == "+" ||operador == "-" || operador == "/" || operador == "*")
            {
                respuesta = operador;
            }

            return respuesta;
        }


        public double Operar(Numero num1, Numero num2, string operador)
        {
            double respuesta = 0;

            operador = ValidarOperador(operador);

            switch(operador)
            {
                case "+":
                    respuesta = num1 + num2;
                    break;
                case "-":
                    respuesta = num1 - num2;
                    break;
                case "*":
                    respuesta = num1 * num2;
                    break;
                case "/":
                    if(num2 != 0)
                    {
                        respuesta = num1 / num2;
                    }                        
                    break;
            }

            return respuesta;
        }
    }
}
