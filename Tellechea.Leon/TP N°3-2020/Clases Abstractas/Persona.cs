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
            set { dni = Convert.ToInt32(value); }
        }

        public Persona()
        {
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
            this.nombre = nombre;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, Convert.ToInt32(dni), nacionalidad)
        {
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int ret = -1;

            if (nacionalidad == ENacionalidad.Argentino)
            {
                if (dato >= 1 && dato <= 89999999)
                {
                    ret = dato;
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
                    ret = dato;
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
            int datoEntero;
            int ret = -1;

            if(int.TryParse(dato, out datoEntero) == true && dato.Length == 0 || dato.Length > 8)
            {
                ret = ValidarDni(nacionalidad, datoEntero);
            }
            else
            {
                throw new DniInvalidoException();
            }

            return ret;
        }

        private string ValidarNombreApellido(string dato)
        {
            string ret = "";
            bool retValue = false;

            foreach(char c in dato)
            {
                if(!Char.IsLetter(c))
                {
                    retValue = true;
                    break;
                }
            }

            if (retValue == false)
                ret = dato;

            return ret;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Nombre Completo: {this.apellido} {this.nombre}");
            sb.AppendLine($"Nacionalidad: {this.nacionalidad}");
            sb.AppendLine($"DNI: {this.dni}");

            return sb.ToString();
        }
    }
}
