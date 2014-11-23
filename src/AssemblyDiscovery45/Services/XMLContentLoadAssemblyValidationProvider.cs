using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssemblyDiscovery.Extensions;

namespace AssemblyDiscovery.Services
{
    public class XMLContentLoadAssemblyValidationProvider : ILoadAssemblyValidationProvider
    {
        protected string XMLContent { get; set; }

        public XMLContentLoadAssemblyValidationProvider(string xmlContent)
        {
            XMLContent = xmlContent;
        }

        public virtual AssemblyValidator LoadValidator()
        {
            if (string.IsNullOrWhiteSpace(XMLContent))
                return null;

            return XMLContent.ToObjectFromXml<AssemblyValidator>(Encoding.UTF8);
        }
    }
}
