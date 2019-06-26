using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Diagnostics;
using System.IO;
using SupportedLanguage;
using Errors;

namespace CodeExecuter
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Executer : IExecuter
    {
        static string codefolder = @"f:\\codefolder";
        private static int tlimit = 5000;
        public error executeCode(language lang, string filename, string input, string output)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WorkingDirectory = codefolder;
            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            switch (lang)
            {
                case language.cpp : startInfo.Arguments = @"/C g++ -o "+ filename.Substring(0,filename.Length-4) + " " + filename + " 2> " + output ;
                    Process.Start(startInfo).WaitForExit();
                    string cc = File.ReadAllText(codefolder + @"\"+ output);
                    if (cc.Length != 0)
                    {
                        return error.CE;
                    }
                    startInfo.Arguments = @"/C " + filename.Substring(0, filename.Length - 4);
                    if (input != null)
                        startInfo.Arguments += " < " + input;
                    if(output != null)
                        startInfo.Arguments+=" > " +output;
                    var proc=Process.Start(startInfo);
                    bool re=proc.WaitForExit(tlimit);
                    if (!re)
                    {
                        //foreach (var pro in Process.GetProcessesByName(filename.Substring(0, filename.Length - 4)))
                            //pro.Kill();
                        return error.RE;
                    }
                    //foreach (var pro in Process.GetProcessesByName(filename.Substring(0, filename.Length - 4)))
                       // pro.Kill();
                    break;
            }
            return error.AC;
        }
    }
}
