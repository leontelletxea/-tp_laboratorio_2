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

        /// <summary>
        /// Incializa el atributo de universitario con un valor por defecto
        /// </summary>
        public Universitario()
            : base()
        {
            this.legajo = 0;
        }

        /// <summary>
        /// LLama al constructor base e inicializa el legajo con el valor recibido como parametro
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// Compara la igualdad de dos universitarios, por tipo Legajo  y DNI
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns> Retorna true si son iguales, false caso contrario
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

        /// <summary>
        /// Compara la distincion entre dos universitarios, por tipo Legajo  y DNI
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns> Retorna true si son distintos, false caso contrario
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Compara dos univeritarios por medio del ==
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns> Retorna true si son iguales, false caso contrario
        public override bool Equals(object obj)
        {
            bool retVaue = false;

            if (obj is Universitario)
            {
                retVaue = this == (Universitario)obj;
            }

            return retVaue;
        }

        /// <summary>
        /// Concatena los atributos de Universitario y sus atributos base Persona en un Stringbuilder
        /// </summary>
        /// <returns></returns> Retorna el StringBuilder con los datos de Universitario y sus atributos base Persona
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.Append($"LEGAJO NÚMERO: {this.legajo}");

            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();
    }
}
