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
        private ECapacidad almacenamiento;
        private string lanzamiento;

        public Int32 Id { get => id; set => id = value; }
        public Single Precio { get => precio; set => precio = value; }
        public ECapacidad Almacenamiento { get => almacenamiento; set => almacenamiento = value; }
        public String Lanzamiento { get => lanzamiento; set => lanzamiento = value; }

        /// <summary>
        /// Constructor por defecto para que se pueda serializar a xml
        /// </summary>
        public Sony()
        {
        }

        /// <summary>
        /// Inicializa los atributos de Sony
        /// </summary>
        /// <param name="id"></param>
        /// <param name="precio"></param>
        /// <param name="almacenamiento"></param>
        /// <param name="lanzamiento"></param>
        public Sony(int id, float precio, ECapacidad almacenamiento, string lanzamiento)
        {
            this.id = id;
            this.precio = precio;
            this.almacenamiento = almacenamiento;
            this.lanzamiento = lanzamiento;
        }

        /// <summary>
        /// Gurarda los atributos de Sony en un StringBuilder
        /// </summary>
        /// <returns></returns> La cadena con la informacion
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Id: {this.id}");
            sb.AppendLine($"Precio: {this.precio.MetodoExtension()}");
            sb.AppendLine($"Almacenamiento: {this.almacenamiento}");
            sb.AppendLine($"Lanzamiento: {this.lanzamiento}");

            return sb.ToString();
        }

        /// <summary>
        /// Dos Sony son iguales si tienen el mismo id
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns> True si son iguales, false caso contrario
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

        /// <summary>
        /// Dos Sony son distintos si tienen el mismo id
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns> True si son distintos, false caso contrario
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
