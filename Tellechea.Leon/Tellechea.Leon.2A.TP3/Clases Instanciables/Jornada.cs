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

        /// <summary>
        /// Instancia la coleccion "alumnos"
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Llama al constructor anterior e inicializa los atributos de jornada con los valores recibidos como parametro 
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        /// <summary>
        /// Compara la igualdad entre una jornada y un alumno
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns> true si el alumno se encuentra en la jornada, false caso contrario
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

        /// <summary>
        ///  Compara la distincion entre una jornada y un alumno
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns> true si el alumno NO se encuentra en la jornada, false caso contrario
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a la jornada, siempre que el alumno no se encuentre ya en la misma
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns> Retorna la jornada recibida como parametro
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

        /// <summary>
        /// Concatena los datos de la Jornada en un StringBuilder
        /// </summary>
        /// <returns></returns> El StringBuilder con los datos de la jornada
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

        /// <summary>
        /// Guarda la los datos de la jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns> Retorna true si se pudo guardar, false caso contrario
        public static bool Guardar(Jornada jornada)
        {
            bool retValue = false;

            Texto t = new Texto();
            retValue = t.Guardar("Jornada.txt", jornada.ToString());

            return retValue;
        }

        /// <summary>
        /// Lee los datos de la jornada desde un archivo de texto
        /// </summary>
        /// <returns></returns> el string con los datos de la jornada
        public static string Leer()
        {
            string jornada;

            Texto t = new Texto();
            t.Leer("Jornada.txt", out jornada);

            return jornada.ToString();
        }
    }
}
