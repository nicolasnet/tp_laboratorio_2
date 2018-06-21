using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackinIdRepetidoException : Exception
    {
        public TrackinIdRepetidoException(string mensaje) 
            : this(mensaje, null)
        {
        }

        public TrackinIdRepetidoException(string mensaje, Exception inner) 
            : base(mensaje, inner)
        {
        }
    }
}
