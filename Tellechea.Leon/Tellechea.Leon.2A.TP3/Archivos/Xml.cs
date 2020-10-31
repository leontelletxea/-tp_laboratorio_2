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
        /// <summary>
        /// Serializa y guarda el object T "datos" recibido como parametro en el archivo xml "archivo"
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns> Retorna true si se pudo guardar, false caso contrario
        public bool Guardar(string archivo, T datos)
        {
            bool retValue = false;

            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(writer, datos);
                    retValue = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retValue;
        }

        /// <summary>
        /// Deserializa y lee el archivo xml "archivo" recibido como parametro y lo guarda en el out object T "datos"
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns> Retorna true si se pudo leer, false caso contrario
        public bool Leer(string archivo, out T datos)
        {
            bool retValue = false;

            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    datos = (T)ser.Deserialize(reader);
                    retValue = true;
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }

            return retValue;
        }
    }
}
