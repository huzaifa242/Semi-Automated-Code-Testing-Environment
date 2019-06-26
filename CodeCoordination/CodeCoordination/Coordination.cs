using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CodeCoordination.CodeExecuterService;
using SupportedLanguage;
using Errors;
using System.IO;
namespace CodeCoordination
{
    public class Coordination : ICoordination
    {
        CodeExecuterService.ExecuterClient codecli = new ExecuterClient();
        private string test, casegen = "casegen.txt", codep, codes, opp = "opp.txt", ops = "ops.txt";
        private language testl, codepl, codesl;
        public error e;
        public void execute()
        {
            DateTime start = DateTime.Now;
            while (true)
            {
                int f = 0;
                gentestcase();
                runp();
                runs();
                string line1, line2;
                string l = "";
                f = ops.Length;
                for(int i=0;i<f-3;i=i+1)
                {
                    l = l + ops[i];
                }
                line1 = File.ReadAllText(@"F:\codefolder\" + opp);
                line2 = File.ReadAllText(@"F:\codefolder\" + ops);
                if (line2.Contains(l))
                {
                    FileStream File1 = new FileStream(@"F:\codefolder\" + ops + "result", FileMode.OpenOrCreate, FileAccess.Write);
                    using (StreamWriter sw = new StreamWriter(File1))
                    {
                        sw.WriteLine(ops + " have compilation error: ");
                        sw.WriteLine(line2);
                    }
                    File1.Close();
                    return;
                }
                if (line1 != line2)
                {
                    FileStream File1 = new FileStream(@"F:\codefolder\"+ops+"result", FileMode.OpenOrCreate, FileAccess.Write);
                    using (StreamWriter sw = new StreamWriter(File1))
                    {
                        sw.WriteLine(ops +" gets a failure on");
                        string line3 = File.ReadAllText(@"F:\codefolder\casegen.txt");
                        sw.WriteLine(line3);
                    }
                    //File.Delete(@"F:\codefolder\" + opp);
                    //File.Delete(@"F:\codefolder\" + opp);
                    File1.Close();
                    return;
                }
                if((DateTime.Now-start).TotalSeconds >=120)
                {
                    FileStream File1 = new FileStream(@"F:\codefolder\"+ops+"result", FileMode.OpenOrCreate, FileAccess.Write);
                    using (StreamWriter sw = new StreamWriter(File1))
                    {
                        sw.WriteLine(ops+" gets the success");
                    }
                    File1.Close();
                    return;
                }
            }
        }

        public void gentestcase()
        {
            codecli.executeCode(testl, test, null, casegen);
        }

        public void runp()
        {
            codecli.executeCode(codepl, codep, casegen, opp);
        }
        public void runs()
        {
            codecli.executeCode(codesl, codes, casegen, ops);
        }

        public void settestl(language lang)
        {
            testl = lang;
        }
        public void setcodepl(language lang)
        {
            codepl = lang;
        }
        public void setcodesl(language lang)
        {
            codesl = lang;
        }
        public void settest(string name)
        {
            test = name;
        }
        public void setcasegen(string name)
        {
            casegen = name;
        }
        public void setcodep(string name)
        {
            codep = name;
        }
        public void setcodes(string name)
        {
            codes = name;
        }
        public void setopp(string name)
        {
            opp = name;
        }
        public void setops(string name)
        {
            ops = name;
        }
    }
}
