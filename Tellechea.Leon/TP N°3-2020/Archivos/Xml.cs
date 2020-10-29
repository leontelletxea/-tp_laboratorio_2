using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            bool retValue = false;

            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, System.Text.Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));

                    ser.Serialize(writer, datos);
                }
                retValue = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retValue;
        }

        public bool Leer(string archivos, out T datos)
        {
            bool retValue = false;

            try
            {
                using (XmlTextReader reader = new XmlTextReader("Datos.xml"))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));

                    datos = (T)ser.Deserialize(reader);

                    Console.WriteLine(datos.ToString());
                }
                retValue = true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }

            return retValue;
        }
    }
}
