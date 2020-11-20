using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VR : Sony
    {
        protected float peso;

        public VR()
        {
        }

        public VR(int id, float precio, int almacenamiento, string lanzamiento, float peso)
            : base(id, precio, almacenamiento, lanzamiento)
        {
            this.peso = peso;
        }

        public Single Peso { get => peso; set => peso = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);
            sb.Append(base.ToString());
            sb.AppendLine($"Peso: {this.peso}");

            return sb.ToString();
        }
    }
}
