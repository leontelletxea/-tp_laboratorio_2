using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException()
        {
            Console.WriteLine("Nacionalidad invalida...");
        }

        public NacionalidadInvalidaException(string message)
        {
            Console.WriteLine(message);
        }
    }
}
