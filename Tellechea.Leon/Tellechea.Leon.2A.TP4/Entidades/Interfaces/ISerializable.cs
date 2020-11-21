using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface ISerializable
    {
        bool Serializar(string archivo, List<Sony> datos);

        bool Deserializar(string archivos, out List<Sony> datos);
    }
}
