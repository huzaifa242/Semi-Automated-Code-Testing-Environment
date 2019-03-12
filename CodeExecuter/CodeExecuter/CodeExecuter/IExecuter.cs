using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SupportedLanguage;
using Errors;

namespace CodeExecuter
{
    [ServiceContract]
    public interface IExecuter
    {
        [OperationContract]
        error executeCode(language lang, string filename,string input,string output);  
    }

    
}
