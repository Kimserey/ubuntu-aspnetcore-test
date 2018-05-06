using Microsoft.AspNetCore.Mvc;

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
