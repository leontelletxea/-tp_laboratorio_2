using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface ISerializable<T>
    {
        bool Serializar(string archivo, T datos);

        bool Deserializar(string archivos, out T datos);
    }
}
