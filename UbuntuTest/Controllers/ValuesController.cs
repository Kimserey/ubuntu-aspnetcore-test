using Microsoft.AspNetCore.Mvc;
using System;

namespace UbuntuTest.Controllers
{
    [Route("values")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new string[] { "Data one", "Data two" });
        }
    }
}
