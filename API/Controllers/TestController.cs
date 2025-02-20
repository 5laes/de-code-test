using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TestController : BaseApiController
    {
        [HttpGet]
        public ActionResult<string> GetString()
        {
            return Ok(new {message = "Hello World!"});
        }
    }
}