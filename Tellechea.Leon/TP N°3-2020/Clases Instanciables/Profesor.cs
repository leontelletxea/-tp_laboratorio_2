using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace Clases_Instanciables
{
    public sealed class Profesor : EntidadesAbstractas.Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        static Profesor()
        {
            Profesor.random = new Random();
        }

        private Profesor()
            : base()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {

                switch (Profesor.random.Next(0, 3))
                {
                    case 0:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                        break;
                    case 1:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                        break;
                    case 2:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                        break;
                    case 3:
                        this.clasesDelDia.Enqueue(Universidad.EClases.SPD);
                        break;
                }
            }
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(ParticiparEnClase());

            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA: ");
            foreach (Universidad.EClases c in this.clasesDelDia)
            {
                sb.AppendLine(c.ToString());
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos();
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retValue = false;
            
            if((object)i != null && (object)clase != null)
            {
                foreach (Universidad.EClases c in i.clasesDelDia)
                {
                    if (c == clase)
                    {
                        retValue = true;
                        break;
                    }
                }
            }

            return retValue;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}
