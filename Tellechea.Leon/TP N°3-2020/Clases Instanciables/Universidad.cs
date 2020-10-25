using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { alumnos = value; }
        }

        public List<Jornada> Jornada
        {
            get { return jornada; }
            set { jornada = value; }
        }

        public List<Profesor> Instructores
        {
            get { return profesores; }
            set { profesores = value; }
        }

        public Jornada this[int i]
        {
            get { return jornada[i]; }
            set { jornada[i] = value; }
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retValue = false;

            foreach (Alumno item in g.alumnos)
            {
                if (item == a)
                {
                    retValue = true;
                    break;
                }
            }

            return retValue;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retValue = false;

            foreach (Profesor item in g.profesores)
            {
                if (item == i)
                {
                    retValue = true;
                    break;
                }
            }

            return retValue;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            foreach (Profesor p in g.profesores)
            {
                if (p == clase)
                {
                    Jornada j = new Jornada(clase, p);
                    g.jornada.Add(j);
                    foreach (Alumno a in g.alumnos)
                    {
                        if (a == clase)
                        {
                            g.alumnos.Add(a);
                        }
                    }
                    break;
                }
            }

            return g;
        }

        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return g;
        }

        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.profesores.Add(i);
            }

            return g;
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor p = null;

            foreach (Profesor i in u.profesores)
            {
                if (i == clase)
                {
                    p = i;
                    break;
                }
            }

            if (p != null)
            {
                throw new SinProfesorException();
            }

            return p;
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor p = null;

            foreach (Profesor i in u.profesores)
            {
                if (i != clase)
                {
                    p = i;
                    break;
                }
            }

            if (p == null)
            {
                throw new SinProfesorException();
            }

            return p;
        }

        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Alumnos: ");
            foreach (Alumno a in uni.alumnos)
            {
                sb.AppendLine(a.ToString());
            }

            sb.AppendLine("Jornadas: ");
            foreach (Jornada j in uni.jornada)
            {
                sb.AppendLine(j.ToString());
            }

            sb.AppendLine("Profesores: ");
            foreach (Profesor p in uni.profesores)
            {
                sb.AppendLine(p.ToString());
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos(new Universidad());
        }

        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();
            profesores = new List<Profesor>();
        }

        /**public static bool Guardar(Universidad uni)
        {

        }

        public static Universidad Leer()
        {

        }*/
    }
}
