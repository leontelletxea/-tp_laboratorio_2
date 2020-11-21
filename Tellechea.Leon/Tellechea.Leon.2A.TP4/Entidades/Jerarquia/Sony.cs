using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{       
    [XmlInclude(typeof(PlayStation))]
    [XmlInclude(typeof(VR))]
    public abstract class Sony
    {
        private int id;
        private float precio;
        private int almacenamiento;
        private string lanzamiento;

        public Int32 Id { get => id; set => id = value; }
        public Single Precio { get => precio; set => precio = value; }
        public Int32 Almacenamiento { get => almacenamiento; set => almacenamiento = value; }
        public String Lanzamiento { get => lanzamiento; set => lanzamiento = value; }

        public Sony()
        {
        }

        public Sony(int id, float precio, int almacenamiento, string lanzamiento)
        {
            this.id = id;
            this.precio = precio;
            this.almacenamiento = almacenamiento;
            this.lanzamiento = lanzamiento;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Id: {this.id}");
            sb.AppendLine($"Precio: {this.precio.MetodoExtension()}");
            sb.AppendLine($"Almacenamiento: {this.almacenamiento}");
            sb.AppendLine($"Lanzamiento: {this.lanzamiento}");

            return sb.ToString();
        }

        public static bool operator ==(Sony a, Sony b)
        {
            bool retValue = false;

            if ((object)a != null && (object)b != null)
            {
                if (a.id == b.id)
                {
                    retValue = true;
                }
            }

            return retValue;
        }

        public static bool operator !=(Sony a, Sony b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            bool ret = false;
            if (obj is Sony)
            {
                ret = this == (Sony)obj;
            }

            return ret;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
