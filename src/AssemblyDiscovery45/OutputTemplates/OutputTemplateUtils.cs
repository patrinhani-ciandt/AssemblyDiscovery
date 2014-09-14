using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyDiscovery.OutputTemplates
{
    public class OutputTemplateUtils
    {
        private static string getResourceTemplateContent(string resourceTemplateName)
        {
            string result = null;

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = string.Format("AssemblyDiscovery.OutputTemplates.{0}", resourceTemplateName);

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }

            return result;
        }

        public static string GetHTMLTemplateContent()
        {
            return getResourceTemplateContent("HTMLOutTplt.HTMLOutTplt.html");
        }

        public static string GetHTMLGraphTemplateContent()
        {
            return getResourceTemplateContent("HTMLOutTplt.HTMLGraphOutTplt.html");
        }

        public static KeyValuePair<string, string>[] GetHTMLTemplateContentAssets()
        {
            var list = new List<KeyValuePair<string, string>>();

            list.Add(new KeyValuePair<string, string>("jquery-1.11.0.min.js", getResourceTemplateContent("HTMLOutTplt.js.jquery-1.11.0.min.js")));
            list.Add(new KeyValuePair<string, string>("d3.min.js", getResourceTemplateContent("HTMLOutTplt.js.d3.min.js")));
            list.Add(new KeyValuePair<string, string>("dagre-d3.min.js", getResourceTemplateContent("HTMLOutTplt.js.dagre-d3.min.js")));
            list.Add(new KeyValuePair<string, string>("raphael-min.js", getResourceTemplateContent("HTMLOutTplt.js.raphael-min.js")));
            list.Add(new KeyValuePair<string, string>("raphael.pan-zoom.min.js", getResourceTemplateContent("HTMLOutTplt.js.raphael.pan-zoom.min.js")));

            return list.ToArray();
        }

        public static void SaveContent(string filePath, string content)
        {
            SaveContent(filePath, content, Encoding.UTF8);
        }

        public static void SaveContent(string filePath, string content, Encoding encoding)
        {
            using (var writer = new StreamWriter(filePath, false, encoding))
            {
                writer.Write(content);

                writer.Close();
            }
        }

    }
}
