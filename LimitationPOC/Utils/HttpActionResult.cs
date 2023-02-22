using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LimitationPOC.Utils
{
    public class HttpActionResult : IActionResult
    {
        public readonly int _statuscode;
        public readonly object _data;

        public HttpActionResult(int statuscode, object data)
        {
            _statuscode = statuscode;
            _data = data;
        }
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_data)
            {
                StatusCode = _statuscode
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
