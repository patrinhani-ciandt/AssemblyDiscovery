using System;
using System.Collections.Generic;
using System.Linq;

namespace AssemblyDiscovery.Services
{
    public class AssemblyValidationResultSummary
    {
        public IEnumerable<AssemblyTO> Errors { get; set; }
        public IEnumerable<AssemblyTO> Warnings { get; set; }

        public bool HasErrors()
        {
            return ((Errors != null) && (Errors.Count() > 0));
        }
    }
}