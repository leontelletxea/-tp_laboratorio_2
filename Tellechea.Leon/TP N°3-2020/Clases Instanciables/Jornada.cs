using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Jornada(Universidad.EClases clase, Profesor instructor)
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retvalue = false;

            foreach(Alumno item in j.alumnos)
            {
                if(item == a)
                {
                    retvalue = true;
                    break;
                }
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

            sb.AppendLine(this.clase.ToString());
            sb.AppendLine(this.instructor.ToString());

            foreach (Alumno a in this.alumnos)
            {
                sb.AppendLine(a.ToString());
            }

            return sb.ToString();
        }

        /**public bool Guardar(Jornada jornada)
        {

        }

        public string Leer()
        {

        }*/
    }
}
