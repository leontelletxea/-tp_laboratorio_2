using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        /// <summary>
        /// Inicializa los atributos de Alumno con valores por defecto
        /// </summary>
        public Alumno()
            : base()
        {
            this.claseQueToma = Universidad.EClases.Laboratorio;
            estadoCuenta = EEstadoCuenta.AlDia;
        }

        /// <summary>
        /// LLama al constructor base e inicializa el atributo de Alumno "claseQueToma" con el valor recibido como parametro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Llama al constructor anterior e inicializa el atributo de Alumno "estadoCuenta" con el valor recibido como parametro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Concatena los atributos de Alumno y los de sus clases base Llama al metodo ParticiparEnClase(); (Devuelve "ClaseQueToma)
        /// </summary>
        /// <returns></returns> Retorna el StringBuilder con toda la informacion de Alumno
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            if(this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                sb.AppendLine("\nESTADO DE CUENTA: Cuota al día");
            }
            else
            {
                 sb.AppendLine($"\nESTADO DE CUENTA: {this.estadoCuenta}");
            }
            sb.Append(ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Guarda en un StringBuilder la clase que toma el alumno
        /// </summary>
        /// <returns></returns> El StringBuilder con la clase que toma
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"TOMA CLASES DE {this.claseQueToma}");

            return sb.ToString();
        }

        /// <summary>
        /// Hace publicos los datos de Alumno
        /// </summary>
        /// <returns></returns> Retorna el metodo MostrarDatos();
        public override string ToString()
        {
            return MostrarDatos();
        }

        /// <summary>
        /// Compara la igualdad entre un alumno y una clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns> true si el alumno toma la clase y el "estadoCuenta" de alumno es != Deudor, false caso contrario
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retValue = false;

            if ((object)a != null && (object)clase != null)
            {
                if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
                {
                    retValue = true;
                }
            }

            return retValue;
        }

        /// <summary>
        /// Compara la distincion entre un Alumno y una clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns> true si el alumno NO toma la clase, false caso contrario
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool retValue = false;

            if ((object)a != null && (object)clase != null)
            {
                if (a.claseQueToma != clase)
                {
                    retValue = true;
                }
            }

            return retValue;
        }
    }
}
