using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return clase; }
            set { clase = value; }
        }

        public Profesor Instructor
        {
            get { return instructor; }
            set { instructor = value; }
        }

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retValue = false;

            if ((object)j != null)
            {
                foreach (Alumno item in j.alumnos)
                {
                    if ((Universitario)item == (Universitario)a)
                    {
                        retValue = true;
                        break;
                    }
                }
            }

            return retValue;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if ((object)j != null && (object)a != null)
            {
                if (j != a)
                {
                    j.alumnos.Add(a);
                }
            }

            return j;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"CLASE DE {this.clase} ");
            sb.Append($"POR {this.instructor}");

            if (this.alumnos != null)
            {
                sb.AppendLine("ALUMNOS:");
                foreach (Alumno a in this.alumnos)
                {
                    sb.Append(a.ToString());
                }
            }

            return sb.ToString();
        }

        public static bool Guardar(Jornada jornada)
        {
            bool retValue = false;

            Texto t = new Texto();
            t.Guardar("Jornada.txt", jornada.ToString());
            retValue = true;

            return retValue;
        }

        public static string Leer()
        {
            string jornada;

            Texto t = new Texto();
            t.Leer("Jornada.txt", out jornada);

            return jornada.ToString();
        }
    }
}
