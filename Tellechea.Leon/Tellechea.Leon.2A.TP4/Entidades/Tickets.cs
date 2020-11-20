using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tickets<T> where T : Sony
    {
        public static bool ImprimirTiket(T t)
        {
            string path = Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + @"\tikets.log";
            bool retValue = false;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Hora: {DateTime.Now}");
            sb.AppendLine($"Total: ${t.Precio}");

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
                Console.WriteLine(e.Message);
            }

            return retValue;
        }
    }
}
