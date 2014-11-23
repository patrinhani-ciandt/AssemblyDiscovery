using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyDiscovery
{
    public class AssemblyTO
    {
        #region Members

        private IList<AssemblyTO> referencedAssemblies;

        #endregion

        #region Properties

        public Guid ObjectId { get; private set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public Version AssemblyVersion { get; set; }

        public string VersionCompatibility { get; set; }

        public string RuntimeVersion { get; set; }

        public bool HasInGAC { get; set; }

        public bool LoadError { get; set; }

        public string LoadErrorDescription { get; set; }

        public AssemblyTO ParentAssembly { get; set; }

        public IList<AssemblyTO> ReferencedAssemblies
        {
            get { return referencedAssemblies; }
            set { referencedAssemblies = value; }
        }

        public string Location { get; set; }

        #endregion

        #region Constructors

        public AssemblyTO()
        {
            ObjectId = Guid.NewGuid();
            referencedAssemblies = new List<AssemblyTO>();
        }

        #endregion

        #region Methods (public)

        public override string ToString()
        {
            return FullName;
        }

        #endregion
    }

}
