using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using MainCorreo;

namespace CorreoGomezUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Testear la intanciacion de la lista de paquetes del correo.
        /// </summary>
        [TestMethod]
        public void InicializacionCorreoListPaquetes()
        {
            // arrange
            Correo c = new Correo();

            //act
            object lista = c.Paquetes;

            //assert
            Assert.IsNotNull(lista);
        }


        /// <summary>
        /// Testeo la utilizacion de la exepcion creada en el proyecto para evitar elementos iguales.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackinIdRepetidoException), "Falla el test")]
        public void TestPaquetesNoRepetidos()
        {
            // arrange
            Correo c = new Correo();

            Paquete p1 = new Paquete("Buenos Aires", "000111");
            Paquete p2 = new Paquete("Quilmes", "000111");

            //act
            c += p1;
            c += p2;            
        }
    }
}
