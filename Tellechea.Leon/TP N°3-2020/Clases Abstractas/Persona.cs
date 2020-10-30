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

        public string StringToDNI
        {
            set
            {
                dni = ValidarDni(nacionalidad, value);
            }
        }

        public Persona()
        {
            this.apellido = "";
            this.dni = 0;
            this.nacionalidad = ENacionalidad.Argentino;
            this.nombre = "";
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
            this.nombre = nombre;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, Convert.ToInt32(dni), nacionalidad)
        {
            this.StringToDNI = dni;
        }

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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"NOMBRE COMPLETO: {this.apellido}, {this.nombre}");
            sb.AppendLine($"NACIONALIDAD: {this.nacionalidad}");

            return sb.ToString();
        }
    }
}
