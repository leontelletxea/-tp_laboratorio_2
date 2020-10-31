using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using EntidadesAbstractas;

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
            get
            {
                if (i >= this.jornada.Count || i < 0)
                {
                    return null;
                }
                else
                {
                    return this.jornada[i];
                }
            }

            set
            {
                if (i >= 0 && i < this.jornada.Count)
                {
                    jornada[i] = value;
                }
                else if (i == this.jornada.Count)
                {
                    jornada.Add(value);
                }
            }
        }

        /// <summary>
        /// Intancia las listas 
        /// </summary>
        public Universidad()
        {
            jornada = new List<Jornada>();
            alumnos = new List<Alumno>();
            profesores = new List<Profesor>();
        }

        /// <summary>
        /// Compara la igualdad entre una universidad y un alumno
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns> true si el alumno pertenece a la universidad, false caso contrario
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retValue = false;

            if ((object)g != null)
            {
                foreach (Alumno item in g.alumnos)
                {
                    if (item == a)
                    {
                        retValue = true;
                        break;
                    }
                }
            }

            return retValue;
        }

        /// <summary>
        /// Compara la distincion entre una universidad y un alumno
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns> true si el alumno NO pertenece a la universidad, false caso contrario
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Compara la igualdad entre una universidad y un profesor
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns> Retorna true si el profesor pertenece a la universidad, false caso contrario
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retValue = false;

            if ((object)g != null)
            {
                foreach (Profesor item in g.profesores)
                {
                    if (item == i)
                    {
                        retValue = true;
                        break;
                    }
                }
            }

            return retValue;
        }

        /// <summary>
        /// Compara la distincion entre una universidad y un profesor
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns> Retorna true si el profesor NO pertenece a la universidad, false caso contrario
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Agrega una clase a la universidad, de no ser posible lanza una excepcion SinProfesorException
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns> Retorna la universidad
        public static Universidad operator +(Universidad g, EClases clase)
        {
            bool flag = false;

            if((object)g != null)
            {
                foreach (Profesor p in g.profesores)
                {
                    if (p == clase)
                    {
                        Jornada j = new Jornada(clase, p);
                        foreach (Alumno a in g.alumnos)
                        {
                            if (a == clase)
                            {
                                j.Alumnos.Add(a);
                            }
                        }
                        g.Jornada.Add(j);
                        flag = true;
                        break;
                    }
                }

                if(flag == false)
                {
                    throw new SinProfesorException();
                }
            }

            return g;
        }

        /// <summary>
        /// Agrega un alumno a la universidad, de no ser posible lanza una excepcion AlumnoRepetidoException
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns> Retorna la universidad
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if((object)g != null)
            {
                if (g != a)
                {
                    g.alumnos.Add(a);
                }
                else
                {
                    throw new AlumnoRepetidoException();
                }     
            }

            return g;
        }

        /// <summary>
        /// Agrega un profesor a la universidad si este no pertenece ya a la misma
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns> Retorna la universidad
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if((object)g != null)
            {
                if (g != i)
                {
                    g.profesores.Add(i);
                }
            }

            return g;
        }

        /// <summary>
        /// Compara la igualad entre una universidad y una clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns> Retorna true si hay un profesor que de la clase, false caso contrario
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor p = null;

            if((object)u != null)
            {
                foreach (Profesor i in u.profesores)
                {
                    if (i == clase)
                    {
                        p = i;
                        break;
                    }
                }
            }

            return p;
        }

        /// <summary>
        /// Compara la distincion entre una universidad y una clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns> Retorna true si NO hay profesor que de la clase, false caso contrario
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor p = null;

            if ((object)u != null)
            {
                foreach (Profesor i in u.profesores)
                {
                    if (i != clase)
                    {
                        p = i;
                        break;
                    }
                }
            }

            return p;
        }

        /// <summary>
        /// Concatena los datos de la universidad en un StringBuilder
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns> Retorna el StringBuilder con los datos de la universidad
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            if (uni.jornada != null)
            {
                sb.AppendLine("JORNADA: ");
                foreach (Jornada j in uni.jornada)
                {
                    sb.Append(j.ToString());
                    sb.AppendLine("<------------------------------------------------------------------>\n");
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Hace publicos los datos de la universidad
        /// </summary>
        /// <returns></returns> Retorna el metodo MostrarDatos(); pasandole la universidad 
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Guarda la universidad en un archivo xml
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns> Retorna true si se pudo guardar, false caso contrario
        public static bool Guardar(Universidad uni)
        {
            bool retValue = false;

            Xml<Universidad> x = new Xml<Universidad>();
            retValue = x.Guardar("Universidad.xml", uni);

            return retValue;
        }

        /// <summary>
        /// Lee el archivo xml y guarda la universidad en "uni"
        /// </summary>
        /// <returns></returns> Retorna la universidad Deserializada y guardada
        public static Universidad Leer()
        {
            Universidad uni;

            Xml<Universidad> x = new Xml<Universidad>();
            x.Leer("Universidad.xml", out uni);

            return uni;
        }
    }
}
