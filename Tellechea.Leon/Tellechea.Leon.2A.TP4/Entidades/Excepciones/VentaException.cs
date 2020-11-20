using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VentaException : Exception
    {
        public VentaException(string message, Exception e)
            : base(message , e)
        {
        }
    }
}
