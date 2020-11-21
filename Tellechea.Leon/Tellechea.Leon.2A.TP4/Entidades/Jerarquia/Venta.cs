using Entidades.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class Venta<T> : ISerializable where T : Sony
    {
        public List<T> listaProductos;
        public int capacidad;

        public Venta()
        {
            this.listaProductos = new List<T>();
        }

        public Venta(int capacidad) : this()
        {
            this.capacidad = capacidad;
        }

        public static bool operator ==(Venta<T> venta, T producto)
        {
            bool retValue = false;

            if ((object)venta != null)
            {
                foreach (T item in venta.listaProductos)
                {
                    if (item == producto)
                    {
                        retValue = true;
                        break;
                    }
                }
            }

            return retValue;
        }

        public static bool operator !=(Venta<T> venta, T producto)
        {
            return !(venta == producto);
        }

        public static Venta<T> operator +(Venta<T> venta, T producto)
        {
            try
            {
                if(venta.capacidad > venta.listaProductos.Count)
                {

                    if (venta != producto)
                    {
                        venta.listaProductos.Add(producto);
                    }
                    else
                    {
                        Console.WriteLine("El producto ya se encuentra en la lista");
                    }
                }
                else
                {
                    Console.WriteLine("No hay mas espacio disponible");
                }
            }
            catch(Exception e)
            {
                throw new Exception("Error al agregar el producto a la lista", e);
            }

            return venta;
        }

        public static Venta<T> operator -(Venta<T> venta, T producto)
        {
            try
            {
                if (venta.capacidad > 0)
                {
                    if (venta == producto)
                    {
                        venta.listaProductos.Remove(producto);
                        Tickets<T>.ImprimirTiket(producto);
                        Console.WriteLine($"Venta de: {producto}Se imprimio el ticket!\n");
                    }
                    else
                    {
                        Console.WriteLine("El producto NO se encuentra en la lista");
                    }
                }
                else
                {
                    Console.WriteLine("No hay productos en la lista para vender");
                }
            }
            catch (Exception e)
            {
                throw new VentaException("Error al vender el producto", e);
            }

            return venta;
        }

        private static string MostrarVentas(Venta<T> venta)
        {
            StringBuilder sb = new StringBuilder();

            if (venta.listaProductos != null)
            {   
                sb.AppendLine("\nLISTA DE PRODUCTOS: ");
                sb.AppendLine($"Capacidad: {venta.capacidad}");
                foreach (T item in venta.listaProductos)
                {
                    sb.Append(item.ToString());
                    sb.AppendLine("<------------------------------------------------------------------>\n");
                }
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarVentas(this);
        }

        public override bool Equals(object obj)
        {
            bool ret = false;
            if (obj is Venta<T>)
            {
                ret = this == (Venta<T>)obj;
            }

            return ret;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool Serializar(string archivo, List<Sony> datos)
        {
            bool retValue = false;

            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<Sony>));
                    ser.Serialize(writer, datos);
                    retValue = true;
                }
                Console.WriteLine("Serializado correctamente!");
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error al intentar serializar", e);
            }

            return retValue;
        }

        public bool Deserializar(string archivo, out List<Sony> datos)
        {
            bool retValue = false;

            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<Sony>));
                    datos = (List<Sony>)ser.Deserialize(reader);
                    retValue = true;
                }
                Console.WriteLine("Deserializado correctamente!");
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error al intentar deserializar", e);
            }

            return retValue;
        }
    }
}
