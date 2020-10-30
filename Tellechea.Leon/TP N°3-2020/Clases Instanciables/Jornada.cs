using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

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
            alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retvalue = false;

            if(a == j.clase)
            {
                retvalue = true;
            }

            return retvalue;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
            {
                j.alumnos.Add(a);
            }

            return j;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"CLASE DE {this.clase} ");
            sb.AppendLine($"POR {this.instructor}");

            sb.AppendLine("ALUMNOS:");
            if (this.alumnos != null)
            {
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

            try
            {
                Texto t = new Texto();
                t.Guardar("Jornada.txt", jornada.ToString());
                retValue = true;
            }
            catch(ArchivosException e)
            {
                throw e;
            }

            return retValue;
        }

        public static string Leer()
        {
            string cadena;

            try
            {
                Texto t = new Texto();
                t.Leer("Jornada.txt", out cadena);
            }
            catch (ArchivosException e)
            {
                throw e;
            }

            return cadena;
        }
    }
}
