using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException(string message)
            : base(message)
        {
        }

        public ArchivosException()
            : base("Error en archivos...")
        {
        }

        public ArchivosException(Exception innerException)
            : base("Error en archivo...", innerException)
        {
        }
    }
}
