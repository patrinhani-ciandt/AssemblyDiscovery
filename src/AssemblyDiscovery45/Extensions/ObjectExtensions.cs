using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AssemblyDiscovery.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// From [Bohrium.NET]
        /// Serializes the object into an XML string
        /// </summary>
        /// <remarks>
        /// The object to be serialized should be decorated with the 
        /// <see cref="SerializableAttribute"/>, or implement the <see cref="ISerializable"/> interface.
        /// </remarks>
        /// <param name="source">The object to serialize</param>
        /// <param name="encoding">The Encoding scheme to use when serializing the data to XML</param>
        /// <returns>An XML encoded string representation of the source object</returns>
        public static string ToXml(this object source, Encoding encoding)
        {
            if (source == null)
            {
                throw new ArgumentException("The source object cannot be null.");
            }

            if (encoding == null)
            {
                throw new Exception("You must specify an encoder to use for serialization.");
            }

            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer serializer = new XmlSerializer(source.GetType());
                serializer.Serialize(stream, source);
                stream.Position = 0;

                return encoding.GetString(stream.ToArray());
            }
        }
    }
}
