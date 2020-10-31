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

        public Alumno()
            : base()
        {
            this.claseQueToma = Universidad.EClases.Laboratorio;
            estadoCuenta = EEstadoCuenta.AlDia;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"\nESTADO DE CUENTA: {this.estadoCuenta}");
            sb.AppendLine(ParticiparEnClase());

            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"TOMA CLASES DE: {this.claseQueToma}");

            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos();
        }

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
