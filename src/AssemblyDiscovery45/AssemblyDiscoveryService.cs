using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AssemblyDiscovery
{
    public class AssemblyDiscoveryService
    {
        #region Members

        private Assembly requestedAssembly;

        #endregion

        #region Constructors

        public AssemblyDiscoveryService()
        {
        }

        public AssemblyDiscoveryService(string assemblyPath)
        {
            this.LoadAssembly(assemblyPath);
        }

        #endregion

        #region Methods (public)

        public AssemblyTO GetAssemblyDetail(bool getReferences = false, bool recursive = false)
        {
            AssemblyTO currentAsseblyTO = null;

            if (getReferences)
            {
                currentAsseblyTO = getAssemblyDetailsWithReferences(this.requestedAssembly, recursive);
            }
            else
            {
                currentAsseblyTO = extractDataFromAssembly(this.requestedAssembly);
            }

            return currentAsseblyTO;
        }

        public void LoadAssembly(string assemblyPath)
        {
            loadAssembly(assemblyPath);
        }

        public void LoadAssembly(Assembly assembly)
        {
            loadAssembly(assembly);
        }

        #endregion

        #region Methods (private)

        private void loadAssembly(string assemblyPath)
        {
            if (File.Exists(assemblyPath))
            {
                var assembly = Assembly.LoadFrom(assemblyPath);

                loadAssembly(assembly);
            }
            else
            {
                requestedAssembly = null;
            }
        }

        private void loadAssembly(Assembly assembly)
        {
            try
            {
                configureAssemblyResolver(assembly.Location);

                requestedAssembly = assembly;
            }
            catch (Exception)
            {
                requestedAssembly = null;

                throw new ApplicationException("O arquivo selecionado não é um arquivo Assembly válido.");
            }
        }

        private void configureAssemblyResolver(string assemblyPath)
        {
            bool assemblyFolderIsSameCurrentAppDomain = checkAssemblyFolderIsSameCurrentAppDomain(assemblyPath);

            if (!assemblyFolderIsSameCurrentAppDomain)
            {
                AppDomain.CurrentDomain.AssemblyResolve += currentDomain_AssemblyResolve;
            }
        }

        private bool checkAssemblyFolderIsSameCurrentAppDomain(string asmPath)
        {
            string currentAppDomainDirectoryName = Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ApplicationBase);

            string assemblyDirectoryName = Path.GetDirectoryName(asmPath);

            Debug.Assert(currentAppDomainDirectoryName != null, "currentAppDomainDirectoryName != null");

            return (currentAppDomainDirectoryName.Equals(assemblyDirectoryName, StringComparison.InvariantCultureIgnoreCase));
        }

        private AssemblyTO extractDataFromAssembly(AssemblyName assemblyName)
        {
            var assembly = loadAssemblyByName(assemblyName);

            return extractDataFromAssembly(assembly);
        }

        private AssemblyTO extractDataFromAssembly(Assembly assembly)
        {
            AssemblyName assemblyName = assembly.GetName();

            var assemblyTO = extractDataFromAssemblyName(assemblyName);

            try
            {
                assemblyTO.HasInGAC = assembly.GlobalAssemblyCache;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                assemblyTO.LoadError = true;
                assemblyTO.LoadErrorDescription = ex.Message;
            }

            return assemblyTO;
        }

        private AssemblyTO extractDataFromAssemblyName(AssemblyName assemblyName)
        {
            var assemblyTO = new AssemblyTO();

            assemblyTO.Name = assemblyName.Name.Trim();
            assemblyTO.FullName = assemblyName.FullName.Trim();
            assemblyTO.AssemblyVersion = assemblyName.Version;
            assemblyTO.RuntimeVersion = assemblyName.GetType().Assembly.ImageRuntimeVersion;
            assemblyTO.VersionCompatibility = assemblyName.VersionCompatibility.ToString();

            fillExtraAssemblyInfo(assemblyName, assemblyTO);

            return assemblyTO;
        }

        private void fillExtraAssemblyInfo(AssemblyName assemblyName, AssemblyTO assemblyTO)
        {
            try
            {
                Assembly assembly = loadAssemblyByName(assemblyName);

                assemblyTO.Location = assembly.Location;
                assemblyTO.HasInGAC = assembly.GlobalAssemblyCache;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                assemblyTO.LoadError = true;
                assemblyTO.LoadErrorDescription = ex.Message;
            }
        }

        private AssemblyTO getAssemblyDetailsWithReferences(Assembly currentAssembly, bool recursive = false, AssemblyTO rootAssemblyTO = null)
        {
            var currentAsseblyTO = extractDataFromAssembly(currentAssembly);

            if (rootAssemblyTO == null)
            {
                rootAssemblyTO = currentAsseblyTO;

                foreach (var assName in currentAssembly.GetReferencedAssemblies().ToList())
                {
                    AssemblyTO refAssemblyTO = null;

                    try
                    {
                        if (currentAsseblyTO.ReferencedAssemblies.Any(a => (a.FullName == assName.FullName)))
                            continue;

                        refAssemblyTO = extractDataFromAssemblyName(assName);
                    }
                    catch (FileNotFoundException ex)
                    {
                        refAssemblyTO = extractDataFromAssemblyName(assName);
                        refAssemblyTO.LoadError = true;
                        refAssemblyTO.LoadErrorDescription = ex.Message;
                    }
                    finally
                    {
                        if (refAssemblyTO != null) refAssemblyTO.ParentAssembly = currentAsseblyTO;
                    }

                    currentAsseblyTO.ReferencedAssemblies.Add(refAssemblyTO);
                }

                foreach (var refAssemblyTO in currentAsseblyTO.ReferencedAssemblies.ToList())
                {
                    try
                    {
                        var refAssembly = loadAssemblyByName(refAssemblyTO.FullName);

                        if (recursive)
                        {
                            var refAssemblyTOReferences = getAssemblyDetailsWithReferences(refAssembly, recursive, rootAssemblyTO);

                            refAssemblyTO.ReferencedAssemblies = refAssemblyTOReferences.ReferencedAssemblies.ToList();
                        }
                    }
                    catch (FileNotFoundException)
                    { }
                }
            }
            else
            {
                foreach (var assName in currentAssembly.GetReferencedAssemblies())
                {
                    AssemblyTO refAssemblyTO = null;

                    try
                    {
                        if (rootAssemblyTO.ReferencedAssemblies.Any(a => ((a.ParentAssembly == null) || (a.ParentAssembly.FullName == currentAsseblyTO.FullName)) && (a.FullName == assName.FullName)))
                            continue;

                        refAssemblyTO = extractDataFromAssemblyName(assName);

                        currentAsseblyTO.ReferencedAssemblies.Add(refAssemblyTO);

                        if (recursive)
                        {
                            rootAssemblyTO.ReferencedAssemblies.Add(refAssemblyTO);

                            var refAssembly = loadAssemblyByName(assName);

                            var refAssemblyTOReferences = getAssemblyDetailsWithReferences(refAssembly, recursive, rootAssemblyTO);

                            refAssemblyTO.ReferencedAssemblies = refAssemblyTOReferences.ReferencedAssemblies.ToList();
                        }
                    }
                    catch (FileNotFoundException ex)
                    {
                        refAssemblyTO = extractDataFromAssemblyName(assName);
                        refAssemblyTO.LoadError = true;
                        refAssemblyTO.LoadErrorDescription = ex.Message;

                        currentAsseblyTO.ReferencedAssemblies.Add(refAssemblyTO);

                        if (recursive)
                        {
                            rootAssemblyTO.ReferencedAssemblies.Add(refAssemblyTO);
                        }
                    }
                    finally
                    {
                        if (refAssemblyTO != null) refAssemblyTO.ParentAssembly = currentAsseblyTO;
                    }
                }
            }

            return currentAsseblyTO;
        }

        private Assembly loadAssemblyByPath(string assemblyPath)
        {
            Assembly assemblyLoaded;

            assemblyLoaded = Assembly.LoadFrom(assemblyPath);

            return assemblyLoaded;
        }

        private Assembly loadAssemblyByName(string assemblyName)
        {
            return loadAssemblyByName(new AssemblyName(assemblyName));
        }

        private Assembly loadAssemblyByName(AssemblyName assemblyName)
        {
            Assembly assemblyLoaded;

            assemblyLoaded = Assembly.Load(assemblyName);

            return assemblyLoaded;
        }

        #endregion

        #region Events

        private Assembly currentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            //This handler is called only when the common language runtime tries to bind to the assembly and fails.

            //Retrieve the list of referenced assemblies in an array of AssemblyName.

            Debug.Assert(requestedAssembly.Location != null, "asmPath != null");

            string assemblyDllName = string.Format("{0}.dll", args.Name.Substring(0, args.Name.IndexOf(",", StringComparison.Ordinal)));

            var strTempAssmbPath = Path.Combine(Path.GetDirectoryName(requestedAssembly.Location), assemblyDllName);

            Assembly missedAssembly = null;

            try
            {
                missedAssembly = loadAssemblyByPath(strTempAssmbPath);
            }
            catch (Exception)
            {
                string appDirectory = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

                try
                {
                    missedAssembly = loadAssemblyByPath(Path.Combine(appDirectory, assemblyDllName));
                }
                catch (Exception) { }
            }

            //Return the loaded assembly.
            return missedAssembly;
        }

        #endregion Events
    }

}
