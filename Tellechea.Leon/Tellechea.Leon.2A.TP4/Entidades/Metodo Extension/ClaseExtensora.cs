using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ClaseExtensora
    {
        public static string MetodoExtension(this float f)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("$");
            sb.Append(f.ToString());

            return sb.ToString();
        }
    }
}
