using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException()
        {
            Console.WriteLine("DNI invalido...");
        }

        public DniInvalidoException(Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        public DniInvalidoException(string message)
        {
            Console.WriteLine(message);
        }

        public DniInvalidoException(string message, Exception e)
        {
            Console.WriteLine("{0} Excepcion: {1}", message, e.ToString());
        }
    }
}
