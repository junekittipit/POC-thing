using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimitationPOC.InterfaceSpec;

namespace LimitationPOC.ProcessController
{
    public interface ILimitationProcess
    {
        List<LimitationResponse> GetLimitationDetial(LimitationRequest req);
    }
}
