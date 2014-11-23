using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyDiscovery.Services
{
    public class AssemblyValidationService
    {
        private ILoadAssemblyValidationProvider assemblyValidatorProvider = null;
        private AssemblyDiscoveryService assemblyDiscoveryService = null;
        private AssemblyValidator assemblyValidator;

        #region Constructors

        public AssemblyValidationService(string targetAssemblyPath)
            : this(new AssemblyDiscoveryService(targetAssemblyPath))
        {

        }

        public AssemblyValidationService(AssemblyDiscoveryService discoveryService)
        {
            assemblyDiscoveryService = discoveryService;
        }

        #endregion Constructors

        #region Methods

        public void LoadAssemblyValidatorFromXmlFile(string xmlValidatorFilePath)
        {
            assemblyValidatorProvider = new XMLFileLoadAssemblyValidationProvider(xmlValidatorFilePath);

            assemblyValidator = assemblyValidatorProvider.LoadValidator();
        }

        public AssemblyValidationResultSummary Validate()
        {
            return assemblyValidator.Validate(assemblyDiscoveryService.GetAssemblyDetail(true, false));
        }

        #endregion Methods
    }
}
