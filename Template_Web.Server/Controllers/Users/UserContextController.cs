using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Template_Web.Server.Infrastructure;
using System.Security.Claims;

namespace Template_Web.Server.Controllers.Users
{
    [Authorize]
    [Route("api/Users/UserContext")]
    [ApiController]
    public class UserContextController : BaseController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {


            return Ok(new { Id = "123" , Name = UserContext.Name });
        }
    }
}
