﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        public AlumnoRepetidoException(string message)
       : base(message)
        {
        }

        public AlumnoRepetidoException()
            : base("Alumno repetido.")
        {
        }
    }
}
