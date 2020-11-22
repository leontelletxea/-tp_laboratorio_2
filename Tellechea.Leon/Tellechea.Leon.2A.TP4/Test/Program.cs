using Entidades;
using Entidades.Excepciones;
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
            Venta<Sony> sinEspacio = new Venta<Sony>();
            Venta<Sony> productos = new Venta<Sony>(4);

            PlayStation p1 = new PlayStation(1, 700, ECapacidad.TB1, "2020", 5);
            PlayStation p2 = new PlayStation(2, 800, ECapacidad.GB500, "2020", 5);
            VR v1 = new VR(3, 300, ECapacidad.RAM1GB, "2016", 300);
            VR v2 = new VR(4, 400, ECapacidad.RAM2GB, "2017", 320);
            VR v3 = new VR(5, 400, ECapacidad.RAM3GB, "2018", 320);

            productos -= p1; // Sin productos
            sinEspacio -= p1; // Sin capacidad

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

            try
            {
                productos.Deserializar(@"\invalida.exe", out lAux); // Excepcion
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
