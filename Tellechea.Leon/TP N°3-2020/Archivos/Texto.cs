using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto
    {
        public bool Guardar(string archivo, string datos)
        {
            bool retValue = false;

            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, true))
                {
                    sw.WriteLine(datos.ToString());
                }
                retValue = true;
            }
            catch(Exception e)
            {
                Console.WriteLine("Falló la escritura. Razones: " + e.Message);
            }

            return retValue;
        }

        public bool Leer(string archivo, out string datos)
        {
            bool retValue = false;

            try
            {
                using (StreamReader sw = new StreamReader(archivo, true))
                {
                    datos = sw.ReadToEnd();
                }
                retValue = true;
            }
            catch (Exception e)
            {
                datos = null;
                Console.WriteLine("Falló la escritura. Razones: " + e.Message);
            }

            return retValue;
        }
    }
}
