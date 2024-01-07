using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Template_Web.Accelerator.Builders;
using Template_Web.Accelerator.Domain;

namespace Template_Web.Server.Controllers
{
    public class BaseController : ControllerBase
    {
        public Guid UserId => Guid.Parse(HttpContext.User.FindFirst("ContextUserId")?.Value);

        private UserContext _userContext;
        public UserContext UserContext
        {
            get
            {
                if(_userContext == null)
                {
                    _userContext = new UserContextBuilder().Build(UserId);
                }

                return _userContext;
            }
        }
    }
}
