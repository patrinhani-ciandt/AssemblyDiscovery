using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AssemblyDiscovery.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// From [Bohrium.NET]
        /// Deserializes an XML string into an object instance
        /// </summary>
        /// <typeparam name="T">The type of object to deserialize</typeparam>
        /// <param name="str">The XML string representantion of the object</param>
        /// <param name="encoding">The encoding scheme to use when deserializing the object</param>
        /// <returns>An instance of T</returns>
        public static T ToObjectFromXml<T>(this string str, Encoding encoding)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("The source string cannot be null or empty");
            }

            if (encoding == null)
            {
                throw new ArgumentException("An encoding scheme must be specified");
            }

            using (var stream = str.ToStream(encoding))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stream);
            }
        }

        /// <summary>
        /// From [Bohrium.NET]
        /// Coneverts a string into a <see cref="Stream"/>, using the encoding method specified in
        /// </summary>
        /// <param name="str">The string to convert</param>
        /// <returns>A stream representation of the source string</returns>
        public static Stream ToStream(this string str)
        {
            return ToStream(str, Encoding.UTF8);
        }

        /// <summary>
        /// From [Bohrium.NET]
        /// Coneverts a string into a <see cref="Stream"/>
        /// </summary>
        /// <param name="str">The string to convert</param>
        /// <param name="encoding">The encoding scheme to use for the conversion</param>
        /// <returns>A stream representation of the source string</returns>
        public static Stream ToStream(this string str, Encoding encoding)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("The source string cannot be null or empty");
            }
            if (encoding == null)
            {
                throw new ArgumentException("An encoding scheme must be specified");
            }

            return new MemoryStream(str.ToByteArray(encoding));
        }

        /// <summary>
        /// From [Bohrium.NET]
        /// Converts a string into a byte array, using the encoding method specified in
        /// </summary>
        /// <param name="str">The string to convert</param>
        /// <returns>A byte array representation of the source string</returns>
        public static byte[] ToByteArray(this string str)
        {
            return ToByteArray(str, Encoding.UTF8);
        }

        /// <summary>
        /// From [Bohrium.NET]
        /// Converts a string into a byte array
        /// </summary>
        /// <param name="str">The string to convert</param>
        /// <param name="encoding">The encoding scheme to use for the conversion</param>
        /// <returns>A byte array representation of the source string</returns>
        public static byte[] ToByteArray(this string str, Encoding encoding)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("The source string cannot be null or empty");
            }
            if (encoding == null)
            {
                throw new ArgumentException("An encoding scheme must be specified");
            }

            return encoding.GetBytes(str);
        }
    }
}
