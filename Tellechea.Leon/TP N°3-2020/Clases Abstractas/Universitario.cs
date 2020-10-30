using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario()
            : base()
        {
            this.legajo = 0;
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retValue = false;

            if ((object)pg1 != null && (object)pg2 != null)
            {
                if (pg1.GetType() == pg2.GetType() && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI))
                {
                    retValue = true;
                }
            }

            return retValue;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        public override bool Equals(object obj)
        {
            bool retVaue = false;

            if (obj is Universitario)
            {
                retVaue = this == (Universitario)obj;
            }

            return retVaue;
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.Append($"LEGAJO NUMERO: {this.legajo}");

            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();
    }
}
