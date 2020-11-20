using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PlayStation : Sony
    {
        private string modelo;

        public PlayStation()
        {
        }

        public PlayStation(int id, float precio, int almacenamiento, string lanzamiento, string modelo)
            : base(id, precio, almacenamiento, lanzamiento)
        {
            this.modelo = modelo;
        }

        public String Modelo { get => modelo; set => modelo = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);
            sb.Append(base.ToString());
            sb.AppendLine($"Modelo: {this.modelo}");

            return sb.ToString();
        }
    }
}
