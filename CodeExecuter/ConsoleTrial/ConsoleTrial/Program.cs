
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleTrial
{
    class Program
    {
        static void Main()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WorkingDirectory = @"e:\\codefolder";
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = @"/C g++ -o sampl sampl.cpp";
            Process.Start(startInfo).WaitForExit();
            startInfo.Arguments = "/C abc";
            Process.Start(startInfo).WaitForExit();
        }
    }
}
