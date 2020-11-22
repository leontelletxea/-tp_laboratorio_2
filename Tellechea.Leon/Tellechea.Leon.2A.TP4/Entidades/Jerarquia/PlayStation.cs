using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PlayStation : Sony
    {
        private int modelo;

        public Int32 Modelo { get => modelo; set => modelo = value; }

        /// <summary>
        /// Constructor por defecto para poder serializar a xml
        /// </summary>
        public PlayStation()
        {
        }

        /// <summary>
        /// Llama al constructor base e inicializa los atributos de PlayStation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="precio"></param>
        /// <param name="almacenamiento"></param>
        /// <param name="lanzamiento"></param>
        /// <param name="modelo"></param>
        public PlayStation(int id, float precio, ECapacidad almacenamiento, string lanzamiento, int modelo)
            : base(id, precio, almacenamiento, lanzamiento)
        {
            this.modelo = modelo;
        }

        /// <summary>
        /// Guarda los atributos de la Clase base y la actual en un StringBuilder
        /// </summary>
        /// <returns></returns> La cadena con toda la informacion
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);
            sb.Append(base.ToString());
            sb.AppendLine($"Modelo: {this.GetType().Name} {this.modelo}");

            return sb.ToString();
        }
    }
}
