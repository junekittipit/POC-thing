using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimitationPOC.InterfaceSpec
{
    public class LimitationRequest
    {
        public List<string> Rule { get; set; }
        public Dictionary<string,string> LimitationKeyValue { get; set; }
    }
}
