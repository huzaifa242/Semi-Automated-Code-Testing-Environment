using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CodeCoordination.CodeExecuterService;
using SupportedLanguage;

namespace CodeCoordination
{
    public class Coordination : ICoordination
    {
        CodeExecuterService.ExecuterClient codecli = new ExecuterClient();
        private string test, casegen = "casegen.txt", codep, codes, opp = "opp.txt", ops = "ops.txt";
        private language testl, codepl, codesl;
        public void execute()
        {
            gentestcase();
            runp();
            runs();
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
