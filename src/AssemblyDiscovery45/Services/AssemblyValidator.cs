using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AssemblyDiscovery.Services
{
    [Serializable]
    public class AssemblyValidator
    {
        [XmlElement("ValidatorDefinitions")]
        public ValidatorDefinitions ValidatorDefinitions { get; set; }

        public AssemblyValidator()
        {
            ValidatorDefinitions = new ValidatorDefinitions();
        }

        public AssemblyValidationResultSummary Validate(AssemblyTO assemblyTO)
        {
            ValidatorDefinitions.ValidateReferences(assemblyTO.ReferencedAssemblies);

            var validationSummary = new AssemblyValidationResultSummary();

            validationSummary.Errors = assemblyTO.ReferencedAssemblies.Where(a => ValidatorDefinitions.ErrorReferences.Contains(a.ObjectId)).ToList();
            validationSummary.Warnings = assemblyTO.ReferencedAssemblies.Where(a => ValidatorDefinitions.WarningReferences.Contains(a.ObjectId)).ToList();

            return validationSummary;
        }
    }
}
