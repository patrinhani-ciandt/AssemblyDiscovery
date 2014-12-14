using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.ClassLib01
{
    public class SampleClass
    {
        public static void MethodTest()
        {
            var currentLoggers = log4net.LogManager.GetCurrentLoggers();

            Console.WriteLine("[public static void MethodTest()] from {1} - log4net loggers: {0}", currentLoggers.Count(), typeof(SampleClass).FullName);
        }
    }
}
