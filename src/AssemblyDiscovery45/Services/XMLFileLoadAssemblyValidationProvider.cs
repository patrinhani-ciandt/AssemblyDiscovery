using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AssemblyDiscovery.Services
{
    public class XMLFileLoadAssemblyValidationProvider : XMLContentLoadAssemblyValidationProvider, ILoadAssemblyValidationProvider
    {
        protected string XMLFilePath { get; set; }

        public XMLFileLoadAssemblyValidationProvider(string xmlFilePath)
            : base(loadXmlContentFile(xmlFilePath))
        {
            XMLFilePath = xmlFilePath;
        }

        private static string loadXmlContentFile(string xmlFilePath)
        {
            var xDoc = XDocument.Load(xmlFilePath);

            return xDoc.ToString();
        }

        public override AssemblyValidator LoadValidator()
        {
            return base.LoadValidator();
        }
    }
}
