using Microsoft.AspNetCore.Mvc;

namespace Template_Web.Server.Controllers
{
    [ApiController]
    [Route("api/ping")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Ping()
        {

            return Ok(DateTime.Now); // return current date and time
        }
    }
}
