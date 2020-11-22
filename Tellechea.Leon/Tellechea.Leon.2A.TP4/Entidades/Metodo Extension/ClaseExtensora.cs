using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ClaseExtensora
    {
        /// <summary>
        /// Extiende la clase Single y agrega el signo $ delante del precio en un StringBuilder
        /// </summary>
        /// <param name="f"></param> La instancia de Single
        /// <returns></returns> La cadena con la informacion
        public static string MetodoExtension(this Single f)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("$");
            sb.Append(f.ToString());

            return sb.ToString();
        }
    }
}
