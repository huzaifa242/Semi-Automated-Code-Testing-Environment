using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetClient.Models
{
    public class language
    {
        public enum lang{
            cpp,
            c,
            python2,
            python3,
            java
        }

        public lang getlang { get; set; }
    }
}