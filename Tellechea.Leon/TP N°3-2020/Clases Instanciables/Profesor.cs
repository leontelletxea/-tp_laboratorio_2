using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        static Profesor()
        {
            random = new Random();
        }

        private Profesor()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            Profesor aux = new Profesor();
            this.clasesDelDia = aux.clasesDelDia;
            aux = null;
        }

        private void _randomClases()
        {
            int clase;

            clase = random.Next(0, 3);

            switch (clase)
            {
                case 0:
                    clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                    break;
                case 1:
                    clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                    break;
                case 2:
                    clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                    break;
                case 3:
                    clasesDelDia.Enqueue(Universidad.EClases.SPD);
                    break;
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

            sb.AppendLine($"Clases del dia: ");

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
            
            if(i.clasesDelDia.Contains(clase)==true)
            {
               retValue = true;
            }

            return retValue;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}
