using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Template_Web.Accelerator.Builders;
using Template_Web.Accelerator.Models.Authentication;
using Template_Web.Accelerator.Services.Security;
using Template_Web.Accelerator.Services.Storage;
using System.Security.Claims;

namespace Template_Web.Server.Controllers.Authentication
{
    [ApiController]
    [Route("api/Authentication")]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly ILogger<UserAuthenticationController> _logger;
        private readonly AuthenticationProviderService _authenticationProviderService;

        public UserAuthenticationController(
            ILogger<UserAuthenticationController> logger,
            AuthenticationProviderService authenticationProviderService)
        {
            _logger = logger;
            _authenticationProviderService = authenticationProviderService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] UserAuthenticationRequest request)
        {
            var token = await _authenticationProviderService.AuthenticateAsync(request.Username, request.Password);

            if (string.IsNullOrEmpty(token))
            {
                return NotFound(new { message = "Username or password is incorrect" });
            }

            return Ok(new UserAuthenticationResponse
            {
                Success = true,
                Token = token
            });
        }

        [AllowAnonymous]
        [HttpGet("validatetoken")]
        public async Task<IActionResult> ValidateToken()
        {
            await Console.Out.WriteLineAsync("123");
            var userAuthenticationResponse = await _authenticationProviderService.ValidateToken();
            if (userAuthenticationResponse == null)
            {
                await Console.Out.WriteLineAsync("1");
                return Unauthorized(new { message = "Error" });
            }

            if (!userAuthenticationResponse.Success)
            {
                await Console.Out.WriteLineAsync("2");
                return Unauthorized(new { message = userAuthenticationResponse.Error });
            }

            await Console.Out.WriteLineAsync("Valid");

            //return Ok(new { message = "Token is valid" });
            return Ok(userAuthenticationResponse);
        }

        [Authorize]
        [HttpGet("refreshtoken")]
        public async Task<IActionResult> RefreshToken()
        {
            var token = await _authenticationProviderService.RefreshTokenAsync();

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized(new { message = "Error" });
            }

            return Ok(new UserAuthenticationResponse
            {
                Success = true,
                Token = token
            });
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authenticationProviderService.LogoutAsync();

            return Ok(new { message = "Logout successful" });
        }
    }
}