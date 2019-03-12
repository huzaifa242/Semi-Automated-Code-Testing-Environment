using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCoordination;

namespace ServiceHostCoordinator
{
    class Program
    {
        static void Main(string[] args)
        {
            System.ServiceModel.ServiceHost sh = new System.ServiceModel.ServiceHost(typeof(CodeCoordination.Coordination));
            sh.Open();
            Console.WriteLine("Hello World!");
            Console.ReadKey();
            sh.Close();

        }
    }
}
