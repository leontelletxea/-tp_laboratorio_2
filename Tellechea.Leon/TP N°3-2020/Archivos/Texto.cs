using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            bool retValue = false;

            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, false, Encoding.UTF8))
                {
                    sw.WriteLine(datos);
                    retValue = true;
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }

            return retValue;
        }

        public bool Leer(string archivo, out string datos)
        {
            bool retValue = false;

            try
            {
                using (StreamReader sw = new StreamReader(archivo, Encoding.UTF8))
                {
                    datos = sw.ReadToEnd();
                    retValue = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retValue;
        }
    }
}
