using SampleProject.ClassLib01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var currentLoggers = log4net.LogManager.GetCurrentLoggers();

            SampleClass.MethodTest();

            Console.WriteLine("Press <ENTER> to exit.");
            Console.ReadLine();
        }
    }
}
