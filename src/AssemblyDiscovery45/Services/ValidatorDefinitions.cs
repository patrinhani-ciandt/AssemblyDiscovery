using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace AssemblyDiscovery.Services
{
    [Serializable]
    public class ValidatorDefinitions
    {
        public List<ValidatorDefinitionReference> References { get; set; }

        private ConcurrentBag<Guid> errorReferences = new ConcurrentBag<Guid>();
        private ConcurrentBag<Guid> warningReferences = new ConcurrentBag<Guid>();

        public IEnumerable<Guid> ErrorReferences
        {
            get
            {
                return errorReferences.ToList();
            }
        }

        public IEnumerable<Guid> WarningReferences
        {
            get
            {
                return warningReferences.ToList();
            }
        }

        #region Methods

        public ValidatorDefinitions WithReferences(params ValidatorDefinitionReference[] references)
        {
            if ((references == null) || (references.Length <= 0))
                return this;

            if (References == null)
                References = new List<ValidatorDefinitionReference>();

            foreach (var item in references)
            {
                References.Add(item);
            }

            return this;
        }

        public void ValidateReferences(IEnumerable<AssemblyTO> assemblies)
        {
            foreach (var item in assemblies)
            //foreach (var item in assemblies.AsParallel())
            {
                validateReference(item);
            }
        }

        private void validateReference(AssemblyTO assembly)
        {
            foreach (var item in References)
            //foreach (var item in References.AsParallel())
            {
                var isValid = item.IsValid(assembly);

                if ((isValid.HasValue) && (!isValid.Value))
                {
                    switch (item.ErrorType)
                    {
                        case ValidatorDefinitionReferenceErrorType.Warning:
                            warningReferences.Add(assembly.ObjectId);
                            break;
                        case ValidatorDefinitionReferenceErrorType.Error:
                            errorReferences.Add(assembly.ObjectId);
                            break;
                    }
                }
            }
        }

        #endregion Methods
    }

    public enum ValidatorDefinitionReferenceErrorType
    {
        Warning = 1,
        Error = 2
    }

    [Serializable]
    public class ValidatorDefinitionReference
    {
        [XmlIgnore]
        public Guid ObjectId { get; private set; }
        [XmlAttribute]
        public string AssemblyName { get; set; }
        [XmlAttribute]
        public string Version { get; set; }
        [XmlAttribute]
        public bool Allowed { get; set; }
        [XmlAttribute]
        public ValidatorDefinitionReferenceErrorType ErrorType { get; set; }

        public ValidatorDefinitionReference()
        {
            ObjectId = Guid.NewGuid();
            AssemblyName = string.Empty;
            Version = "*";
            Allowed = false;
            ErrorType = ValidatorDefinitionReferenceErrorType.Error;
        }

        public bool? IsValid(AssemblyTO assembly)
        {
            if (!testAssemblyName(assembly.Name))
                return null;

            var isVersionMatch = testVersionMach(assembly.AssemblyVersion);

            var res = false;

            if (Allowed)
                res = (isVersionMatch);
            else
                res = (isVersionMatch == false);

            return res;
        }

        private bool testAssemblyName(string assemblyName)
        {
            return Regex.IsMatch(assemblyName, getAssemblyNameRegexPatt());
        }

        private bool testVersionMach(Version assemblyVersion)
        {
            var targetAssemblyVersion = new Version(assemblyVersion.ToString());

            string regexVersion = @"(?<comp>((<=)|(>=)|(=)|(>)|(<)))?(?<version>((?<any_version>[*])|(?<spec_version>(\d+|(?<ver_cw_maj>[*]))[.](\d+|(?<ver_cw_min>[*]))[.](\d+|(?<ver_cw_build>[*]))[.](\d+|(?<ver_cw_rev>[*])))))?";

            var matchVersion = Regex.Match(Version, regexVersion);

            bool isAnyVersion = matchVersion.Groups["any_version"].Success;

            if (isAnyVersion) return true;

            string strComp = "=";
            string strTestVersion = matchVersion.Groups["spec_version"].Value;

            if ((matchVersion.Groups["ver_cw_maj"].Success)
                || (matchVersion.Groups["ver_cw_min"].Success)
                || (matchVersion.Groups["ver_cw_build"].Success)
                || (matchVersion.Groups["ver_cw_rev"].Success))
            {
                strTestVersion = strTestVersion.Replace(".*", ".0");

                targetAssemblyVersion = new Version(
                    (matchVersion.Groups["ver_cw_maj"].Success) ? 0 : targetAssemblyVersion.Major,
                    (matchVersion.Groups["ver_cw_min"].Success) ? 0 : targetAssemblyVersion.Minor,
                    (matchVersion.Groups["ver_cw_build"].Success) ? 0 : targetAssemblyVersion.Build,
                    (matchVersion.Groups["ver_cw_rev"].Success) ? 0 : targetAssemblyVersion.Revision
                );
            }

            var testVersion = new Version(strTestVersion);

            if (matchVersion.Groups["comp"].Success)
            {
                strComp = matchVersion.Groups["comp"].Value;
            }

            switch (strComp)
            {
                case "=":
                    return (targetAssemblyVersion == testVersion);
                case ">":
                    return (targetAssemblyVersion > testVersion);
                case "<":
                    return (targetAssemblyVersion < testVersion);
                case "<=":
                    return (targetAssemblyVersion <= testVersion);
                case ">=":
                    return (targetAssemblyVersion >= testVersion);
            }

            return true;
        }

        private string getAssemblyNameRegexPatt()
        {
            string regex = AssemblyName;

            regex = regex.Replace(".", "[.]");

            regex = regex.Replace("*", @"\w+");

            regex = string.Format("^{0}$", regex);

            return regex;
        }
    }
}