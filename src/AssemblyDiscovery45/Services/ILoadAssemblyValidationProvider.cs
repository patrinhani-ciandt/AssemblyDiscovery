using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyDiscovery.Services
{
    public interface ILoadAssemblyValidationProvider
    {
        AssemblyValidator LoadValidator();
    }
}
