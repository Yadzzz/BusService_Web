using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Template_Web.Server.Infrastructure;
using Template_Web.Accelerator.Models.Authentication;
using Template_Web.Accelerator.Services.Security;
using Template_Web.Accelerator.Services.Storage;
using System.Security.Claims;

namespace Template_Web.Server.Controllers.Authentication
{
    [Authorize(Policy = "AdminPolicy")]
    [ApiController]
    [Route("api/Authentication/jwt")]
    public class JwtTokenController : ControllerBase
    {
        private readonly ILogger<UserAuthenticationController> _logger;
        private readonly AuthenticationProviderService _authenticationProviderService;

        public JwtTokenController(
            ILogger<UserAuthenticationController> logger,
            AuthenticationProviderService authenticationProviderService)
        {
            _logger = logger;
            _authenticationProviderService = authenticationProviderService;
        }

        [HttpPost("generatetoken/{userId:Guid}")]
        public async Task<IActionResult> GenerateTokenAsync(Guid userId)
        {
            var token = await _authenticationProviderService.ForceAuthenticateAsync(userId);

            return Ok(token);
        }
    }
}