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

        /// <summary>
        /// Inicializa el atributo random Con un valor Random
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Instancia la coleccion de tipo Queue "clasesDelDia" y llama al metodo _randomClases();
        /// </summary>
        private Profesor()
            : base()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        /// <summary>
        /// Instancia la coleccion de tipo Queue "clasesDelDia" y llama al metodo _randomClases(); y llama al constructor base
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        /// <summary>
        /// Selecciona dos clases random y las agrega a la coleccion de tipo Queue
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {

                switch (Profesor.random.Next(0, 4))
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

        /// <summary>
        /// Concatena los datos de Profesor en un StringBuilder 
        /// </summary>
        /// <returns></returns> Retorna el StringBuilder con los datos del profesor
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Recorre la lista de tipo Queue "clasesDelDia" y concatena sus clases en un StringBuilder
        /// </summary>
        /// <returns></returns> Retorna un StringBuilder con las clases del dia
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DÍA: ");
            foreach (Universidad.EClases c in this.clasesDelDia)
            {
                sb.AppendLine(c.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Hace publicos los datos de Profesor
        /// </summary>
        /// <returns></returns> Retorna el metodo MostrarDatos();
        public override string ToString()
        {
            return MostrarDatos();
        }

        /// <summary>
        /// Compara la igualdad entre un profesor y una clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns> Retorna true si el profesor da esa clase, false caso contrario
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

        /// <summary>
        /// Compara la distincion entre un profesor y una clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns> Retorna true si el profesor NO da esa clase, false caso contrario
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}
