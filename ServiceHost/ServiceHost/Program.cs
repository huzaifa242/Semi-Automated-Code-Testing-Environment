using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  CodeExecuter;
using System.ServiceModel;
namespace ServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            System.ServiceModel.ServiceHost sh = new System.ServiceModel.ServiceHost(typeof(CodeExecuter.Executer));
            sh.Open();
            Console.WriteLine("Hello World!");
            Console.ReadKey();
            sh.Close();
            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
