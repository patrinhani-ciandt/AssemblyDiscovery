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

            validationSummary.NotFound = ValidatorDefinitions.ErrorReferences.Where(a => a.ObjectId == Guid.Empty).ToList();
            validationSummary.Errors = ValidatorDefinitions.ErrorReferences.Where(a => a.ObjectId != Guid.Empty).ToList();
            validationSummary.Warnings = ValidatorDefinitions.WarningReferences.Where(a => a.ObjectId != Guid.Empty).ToList();

            return validationSummary;
        }
    }
}
