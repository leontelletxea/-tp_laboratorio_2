using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VR : Sony
    {
        private float peso;

        public Single Peso { get => peso; set => peso = value; }

        /// <summary>
        /// Constructor por defecto para poder serializar a xml
        /// </summary>
        public VR()
        {
        }

        /// <summary>
        /// Llama al contructor base e inicializa los atributos de la clase VR
        /// </summary>
        /// <param name="id"></param>
        /// <param name="precio"></param>
        /// <param name="almacenamiento"></param>
        /// <param name="lanzamiento"></param>
        /// <param name="peso"></param>
        public VR(int id, float precio, ECapacidad almacenamiento, string lanzamiento, float peso)
            : base(id, precio, almacenamiento, lanzamiento)
        {
            this.peso = peso;
        }

        /// <summary>
        /// Concatena la informacion de la clase base y la actual en un StringBuilder
        /// </summary>
        /// <returns></returns> La cadena con toda la informacion
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);
            sb.Append(base.ToString());
            sb.AppendLine($"Peso: {this.peso} Gramos");

            return sb.ToString();
        }
    }
}
