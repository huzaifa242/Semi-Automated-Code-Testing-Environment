using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SupportedLanguage;

namespace CodeCoordination
{
    [ServiceContract]
    public interface ICoordination
    {
        [OperationContract]
        void execute();
        [OperationContract]
        void gentestcase();
        [OperationContract]
        void runp();
        [OperationContract]
        void runs();
        [OperationContract]
        void settest(string name);
        [OperationContract]
        void setcasegen(string name);
        [OperationContract]
        void setcodep(string name);
        [OperationContract]
        void setcodes(string name);
        [OperationContract]
        void setopp(string name);
        [OperationContract]
        void setops(string name);
        [OperationContract]
        void settestl(language lang);
        [OperationContract]
        void setcodepl(language lang);
        [OperationContract]
        void setcodesl(language lang);
    }
}
