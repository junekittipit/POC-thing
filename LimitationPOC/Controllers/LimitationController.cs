using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimitationPOC.InterfaceSpec;
using LimitationPOC.MongoModels;
using LimitationPOC.ProcessController;
using LimitationPOC.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace LimitationPOC.Controllers
{
    [ApiController]
    public class LimitationController : ControllerBase
    {
        private readonly ILimitationProcess process;
        
        public LimitationController(ILimitationProcess process)
        {
            this.process = process;
        }

        [HttpPost("api/LimitationUsage")]
        public IActionResult GetUserprofileBynickname([FromBody] LimitationRequest req)
        {
            var resp = process.GetLimitationDetial(req);
            return new HttpActionResult(StatusCodes.Status200OK, new { Code = 2000, Description = "Success.", Data = resp });
        }

    }
}
