using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Venta<Sony> productos = new Venta<Sony>(4);

            PlayStation p1 = new PlayStation(1, 700, 1000, "2020", "PlayStation5");
            PlayStation p2 = new PlayStation(2, 800, 1500, "2020", "PlayStation5");
            VR v1 = new VR(3, 300, 3, "2016", 300);
            VR v2 = new VR(4, 400, 4, "2017", 320);
            VR v3 = new VR(5, 400, 5, "2018", 320);


            productos += p1;
            productos += p2;
            productos += p1; // Repetido
            productos += v1;
            productos += v2;

            productos += v3; // Sin espacio

            Console.WriteLine(productos.ToString());
            Console.ReadLine();

            productos -= v2;
            productos -= p1;

            Console.WriteLine(productos.ToString());
            Console.ReadLine();

            string path = Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + @"\SonyXml.log";
            List<Sony> lAux;

            productos.Serializar(path, productos.listaProductos);
            productos.Deserializar(path, out lAux);
            Console.ReadLine();
        }
    }
}
