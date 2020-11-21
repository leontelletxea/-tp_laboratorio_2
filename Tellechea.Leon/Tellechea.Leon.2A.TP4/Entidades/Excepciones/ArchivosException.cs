using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException(string message)
            : base(message)
        {
        }

        public ArchivosException(string message, Exception e)
            : base(message, e)
        {
        }
    }
}
