using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario()
        {
            this.legajo = 0;
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, Enacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retValue = false;

            if(pg1.legajo == pg2.legajo && pg1.DNI == pg2.DNI && pg1.Equals(pg2))
            {
                retValue = true;
            }

            return retValue;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        public override bool Equals(object obj)
        {
            bool ret = false;
            if (obj is Universitario)
            {
                ret = this == (Universitario)obj;
            }

            return ret;
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Legajo: {this.legajo}");

            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();
    }
}
