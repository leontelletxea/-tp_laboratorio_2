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

        public Universidad()
        {
            jornada = new List<Jornada>();
            alumnos = new List<Alumno>();
            profesores = new List<Profesor>();
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

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

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

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

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

            if ((object)p == null)
            {
                throw new SinProfesorException();
            }

            return p;
        }

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

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        public static bool Guardar(Universidad uni)
        {
            bool retValue = false;

            try
            {
                Xml<Universidad> x = new Xml<Universidad>();
                x.Guardar("Universidad.xml", uni);
                retValue = true;
            }
            catch (ArchivosException e)
            {
                throw e;
            }

            return retValue;
        }

        public static Universidad Leer()
        {
            Universidad uni;

            try
            {
                Xml<Universidad> x = new Xml<Universidad>();
                x.Leer("Universidad.xml", out uni);
            }
            catch (ArchivosException e)
            {
                throw e;
            }

            return uni;
        }
    }
}
