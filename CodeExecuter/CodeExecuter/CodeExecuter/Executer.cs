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
        static string codefolder = @"e:\\codefolder";
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
                case language.cpp : startInfo.Arguments = @"/C g++ -o "+ filename.Substring(0,filename.Length-4) + " " + filename + " > error.txt";
                    Process.Start(startInfo).WaitForExit();
                    if (new FileInfo("error.txt").Length != 0)
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
                        return error.RE;
                    }
                    break;
            }
            return error.AC;
        }
    }
}
