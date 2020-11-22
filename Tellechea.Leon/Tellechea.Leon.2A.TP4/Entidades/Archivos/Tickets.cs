using Entidades.Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{   /// <summary>
    /// Clase Generica que admite objetos unicamente de tipo Sony o que hereden de Sony
    /// </summary>
    /// <typeparam name="T"></typeparam> Objeto de tipo Sony
    public class Tickets<T> where T : Sony
    {
        /// <summary>
        ///  Imprime la hora y fecha de la venta en un archivo de texto
        /// </summary>
        /// <param name="t"></param> Objeto de tipo Sony
        /// <returns></returns> True si pudo guardar, false caso contrario
        public static bool ImprimirTiket(T t)
        {
            string path = Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + @"\Tikets.log";
            bool retValue = false;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*************************");
            sb.AppendLine($"Hora: {DateTime.Now}");
            sb.AppendLine($"Total: ${t.Precio}");
            sb.AppendLine("*************************");

            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(sb.ToString());
                }

                retValue = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error al imprimir el ticket", e);
            }

            return retValue;
        }
    }
}
