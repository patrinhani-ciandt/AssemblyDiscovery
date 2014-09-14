using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AssemblyDiscovery.OutputTemplates;

namespace AssemblyDiscovery
{
    static class Program
    {
        #region Constants

        private const string regexForValidArgumentOperator = @"([/-](?<opr_name>\w+)([:](?<opr_param>\w+))?)";
        private const string regexFormatForSpecificOperatorName = @"([/-](?<opr_name>{0})([:](?<opr_param>\w+))?)";

        #endregion

        #region Methods (private)

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (hasArgument(args, "o"))
            {
                processExportReportArgument(args);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormPrincipal(getInputAssemblyArgument(args)));
            }
        }

        private static void exportAssemblyDiscoveryReport(string[] args, string inputAssembly, string outPath, string outputArgParam)
        {
            var discoveryService = new AssemblyDiscoveryService(inputAssembly);

            var assemblyDetails = discoveryService.GetAssemblyDetail(true, hasArgument(args, "r"));

            assemblyDetails.ReferencedAssemblies =
                assemblyDetails.ReferencedAssemblies.OrderBy(a => String.Format("{0}+{1}", a.ParentAssembly.Name, a.Name)).ToList();

            if (hasArgument(args, "removeGAC"))
            {
                assemblyDetails.ReferencedAssemblies =
                    assemblyDetails.ReferencedAssemblies.Where(a => !a.HasInGAC).ToList();
            }

            generateOutputReport(assemblyDetails, outPath, outputArgParam);
        }

        private static void generateOutputReport(AssemblyTO referencedAssemblies, string outPath, string outputArgParam)
        {
            string defaultFileExtension = "txt";
            switch (outputArgParam.ToLower())
            {
                case "txt":
                    defaultFileExtension = "txt";
                    break;
                case "html":
                    defaultFileExtension = "html";
                    break;
            }

            if (String.IsNullOrWhiteSpace(outPath))
            {


                outPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, String.Format("assemblyDiscoveryReport.{0}", defaultFileExtension));
            }

            switch (outputArgParam.ToLower())
            {
                case "txt":
                    generateOutputReportAsTXT(referencedAssemblies, outPath);
                    break;
                case "html":
                    generateOutputReportAsHTML(referencedAssemblies, outPath);
                    break;
            }
        }

        private static void generateOutputReportAsHTML(AssemblyTO referencedAssemblies, string outPath)
        {
            string strHtmlTemplate = OutputTemplateUtils.GetHTMLTemplateContent();

            string resultHtml = strHtmlTemplate.Replace("{{analyzedAssembly}}", referencedAssemblies.FullName);

            var tableLineBuilder = new StringBuilder();

            foreach (var referencedAssembly in referencedAssemblies.ReferencedAssemblies)
            {
                tableLineBuilder.AppendLine(String.Format("<tr><td>{0}</td><td>{1}</td></tr>",
                    referencedAssembly.ParentAssembly.Name,
                    referencedAssembly.FullName));
            }

            resultHtml = resultHtml.Replace("{{tbodyContent}}", tableLineBuilder.ToString());

            OutputTemplateUtils.SaveContent(outPath, resultHtml);
        }

        //TODO: Implement Graph output.
        //http://stackoverflow.com/questions/7034/graph-visualization-code-in-javascript
        private static void generateOutputReportAsHTMLGraph(AssemblyTO referencedAssemblies, string outPath)
        {
            string strHtmlTemplate = OutputTemplateUtils.GetHTMLTemplateContent();

            string resultHtml = strHtmlTemplate.Replace("{{analyzedAssembly}}", referencedAssemblies.FullName);

            var scriptBuilder = new StringBuilder();

            var listAssemblies = new List<string>();

            listAssemblies.Add(referencedAssemblies.Name);

            foreach (var referencedAssemblyName in referencedAssemblies.ReferencedAssemblies.Select(a => a.Name).Distinct())
            {
                listAssemblies.Add(referencedAssemblyName);
            }

            //Dracula
            /*
            foreach (var assemblyName in listAssemblies)
            {
                scriptBuilder.AppendLine(String.Format(@"graph.addNode('{0}');", assemblyName));
            }

            foreach (var referencedAssembly in referencedAssemblies.ReferencedAssemblies.OrderBy(a => a.ParentAssembly.Name))
            {
                scriptBuilder.AppendLine(String.Format(@"graph.addEdge('{0}', '{1}', optLink);", referencedAssembly.ParentAssembly.Name, referencedAssembly.Name));
            }
            */

            var nodesHtmlBuilder = new StringBuilder();

            foreach (var assemblyName in listAssemblies)
            {
                scriptBuilder.AppendLine(String.Format(@"graph.addNode('{0}', {1});", assemblyName.Replace(".", ""), "{ label: '" + assemblyName + "' }"));
            }

            foreach (var referencedAssembly in referencedAssemblies.ReferencedAssemblies.OrderBy(a => a.ParentAssembly.Name))
            {
                scriptBuilder.AppendLine(String.Format(@"graph.addEdge(null, '{0}', '{1}');", referencedAssembly.ParentAssembly.Name.Replace(".", ""), referencedAssembly.Name.Replace(".", "")));
            }

            resultHtml = resultHtml.Replace("/*{{javascriptArea}}*/", scriptBuilder.ToString());

            string baseOutPutDir = Path.GetDirectoryName(outPath);
            string outputFileName = Path.GetFileName(outPath);

            string outDir = Path.Combine(baseOutPutDir, "out");

            if (!Directory.Exists(outDir))
            {
                Directory.CreateDirectory(outDir);
            }

            string assetDir = Path.Combine(outDir, "js");

            if (!Directory.Exists(assetDir))
            {
                Directory.CreateDirectory(assetDir);
            }

            var htmlTemplateContentAssets = OutputTemplateUtils.GetHTMLTemplateContentAssets();
            foreach (var assetKey in htmlTemplateContentAssets)
            {
                OutputTemplateUtils.SaveContent(Path.Combine(assetDir, assetKey.Key), assetKey.Value);
            }

            OutputTemplateUtils.SaveContent(Path.Combine(outDir, outputFileName), resultHtml);
        }

        private static void generateOutputReportAsTXT(AssemblyTO referencedAssemblies, string outPath)
        {
            var assRefBuilder = new StringBuilder();

            assRefBuilder.AppendLine(String.Format("Main Assembly: {0}", referencedAssemblies));

            int maxLengthString = referencedAssemblies.ReferencedAssemblies.Max(a => a.ParentAssembly.Name.Length);

            foreach (var referencedAssembly in referencedAssemblies.ReferencedAssemblies)
            {
                if (referencedAssembly.LoadError)
                {
                    assRefBuilder.Append("[LOAD_ERROR]");
                }

                assRefBuilder.AppendLine(String.Format("{0} -> {1}", referencedAssembly.ParentAssembly.Name.PadLeft(maxLengthString), referencedAssembly.FullName));
            }

            OutputTemplateUtils.SaveContent(outPath, assRefBuilder.ToString());
        }

        private static string getArgumentOperatorParameter(string argument)
        {
            string argParam = null;

            if (isValidInputForOperatorArgument(argument))
            {
                var match = Regex.Match(argument, regexForValidArgumentOperator);

                if (match.Success)
                {
                    if (match.Groups["opr_param"].Success)
                    {
                        argParam = match.Groups["opr_param"].Value;
                    }
                }
            }

            return argParam;
        }

        private static string getInputAssemblyArgument(string[] args)
        {
            if (args.Any() && (File.Exists(args.First())))
            {
                return args.First();
            }

            return null;
        }

        private static bool getValidInputsForOperatorArgument(string argument, string argOperator)
        {
            return Regex.IsMatch(argument, String.Format(regexFormatForSpecificOperatorName, argOperator));
        }

        private static bool hasArgument(string[] args, string argument)
        {
            return args.Any(a => getValidInputsForOperatorArgument(a, argument));
        }

        private static bool isValidInputForOperatorArgument(string argument)
        {
            return Regex.IsMatch(argument, regexForValidArgumentOperator);
        }

        private static void processExportReportArgument(string[] args)
        {
            string inputAssembly = getInputAssemblyArgument(args);

            if ((String.IsNullOrWhiteSpace(inputAssembly)) && (File.Exists(inputAssembly)))
                throw new ArgumentNullException("Input Assembly", "You need to set a valid Input Assembly to be analyzed as the fisrt argument.");

            string outputArgument = args.Where(a => getValidInputsForOperatorArgument(a, "o")).FirstOrDefault();

            if (!String.IsNullOrWhiteSpace(outputArgument))
            {
                var outputArgParam = getArgumentOperatorParameter(outputArgument);

                if (String.IsNullOrWhiteSpace(outputArgParam))
                    outputArgParam = "txt";

                var list = new List<string>(args.Where(a => !getValidInputsForOperatorArgument(a, "r")).Distinct().ToArray());

                int indexOfOutputArgument = list.IndexOf(outputArgument);

                string outputPath = list.Skip(indexOfOutputArgument + 1).Take(1).FirstOrDefault();

                exportAssemblyDiscoveryReport(args, inputAssembly, outputPath, outputArgParam);
            }
        }

        #endregion
    }
}
