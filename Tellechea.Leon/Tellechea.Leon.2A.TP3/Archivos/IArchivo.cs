﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public interface IArchivo<T>
    {
        bool Guardar(string archivo, T datos);

        bool Leer(string archivos, out T datos);
    }
}
