using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        public EMarca marca;
        public string chasis;
        public ConsoleColor color;
        private ETamanio tamanio;

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        public ETamanio Tamanio 
        { 
            get { return this.tamanio; }
            set { this.tamanio = value; }
        }

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CHASIS: \r {this.chasis}");
            sb.AppendLine($"MARCA : \r {this.marca.ToString()}");
            sb.AppendLine($"COLOR : \r {this.color.ToString()}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CHASIS: \r {p.chasis}");
            sb.AppendLine($"MARCA : \r {p.marca.ToString()}");
            sb.AppendLine($"COLOR : \r {p.color.ToString()}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            bool returnValue = false;

            if(v1.chasis.ToString() == v2.chasis.ToString())
            {
                returnValue = true;
            }

            return returnValue;
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1.chasis == v2.chasis);
        }
    }
}
