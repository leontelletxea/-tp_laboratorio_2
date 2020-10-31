using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        /// <summary>
        /// Para el set utiliza el metodo ValidarDni(); que recibe un entero
        /// </summary>
        public int DNI
        {
            get { return dni; }

            set 
            {
                if(ValidarDni(nacionalidad, value) != -1)
                    dni = value;
            }
        }

        public ENacionalidad Nacionalidad
        {
            get { return nacionalidad; }
            set { nacionalidad = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        /// <summary>
        /// Para el set utiliza el metodo ValidarDni(); que recibe un string
        /// </summary>
        public string StringToDNI
        {
            set
            {
                dni = ValidarDni(nacionalidad, value);
            }
        }

        /// <summary>
        /// Inicializa los atributos Persona con valores por defecto
        /// </summary>
        public Persona()
        {
            this.apellido = "";
            this.dni = 0;
            this.nacionalidad = ENacionalidad.Argentino;
            this.nombre = "";
        }

        /// <summary>
        /// Llama al constructor anterior e inicializa los atributos Persona con los valores recibidos por parametro
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
            this.nombre = nombre;
        }

        /// <summary>
        /// Llama al constructor anterior y setea DNI con el valor recibido por parametro
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Llama al constructor anterior y setea DNI con el valor recibido por parametro
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, Convert.ToInt32(dni), nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Valida el dni, de ser invalido lanza la excepcion NacionalidadInvalidaException
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns> Retorna -1 si el dni es invalido, caso contrario el dni recibido como parametro
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retValue = -1;

            if (nacionalidad == ENacionalidad.Argentino)
            {
                if (dato >= 1 && dato <= 89999999)
                {
                    retValue = dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }
            else if (nacionalidad == ENacionalidad.Extranjero)
            {
                if (dato >= 90000000 && dato <= 99999999)
                {
                    retValue = dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }

            return dato;
        }

        /// <summary>
        /// Valida que el dni, de ser invalido lanza la excepcion DniInvalidoException
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>  Retorna -1 si el dni es invalido, caso contrario el dni validado por los dos metodos ValidarDni();
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            int retValue = -1;

            if(int.TryParse(dato, out dni) == true && dato.Length < 9)
            {
                retValue = ValidarDni(nacionalidad, dni);
            }
            else
            {
                throw new DniInvalidoException();
            }

            return retValue;
        }

        /// <summary>
        /// Valida que el apellido contenga caracteres validos para nombre y apellido
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns> Retorna un string vacio, de ser invalido, caso contrario el string "dato" 
        private string ValidarNombreApellido(string dato)
        {
            string ret = "";
            bool flag = false;

            foreach(char c in dato)
            {
                if(!Char.IsLetter(c))
                {
                    flag = true;
                    break;
                }
            }

            if(flag == false)
                ret = dato;

            return ret;
        }

        /// <summary>
        /// Concatena los atributos de Persona en un StringBuilder
        /// </summary>
        /// <returns></returns> Retorna el StringBuilder con los datos de Persona
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"NOMBRE COMPLETO: {this.apellido}, {this.nombre}");
            sb.AppendLine($"NACIONALIDAD: {this.nacionalidad}");

            return sb.ToString();
        }
    }
}
