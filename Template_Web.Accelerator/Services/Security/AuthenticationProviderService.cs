using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Template_Web.Accelerator.Models.Authentication;
using Template_Web.Accelerator.Builders;
using Template_Web.Accelerator.Services.Storage;
using System.Security.Claims;
using Template_Web.Accelerator.Services.Email;
using Template_Web.Accelerator.Integrations.ClickSendSms;
using Template_Web.Accelerator.Models.Email;

namespace Template_Web.Accelerator.Services.Security
{
    public class AuthenticationProviderService
    {
        private readonly ILogger<AuthenticationProviderService> _logger;
        private readonly JwtService _jwtService;
        private readonly CookieService _cookieService;
        private readonly IEmailService _emailService;

        public AuthenticationProviderService(
                       ILogger<AuthenticationProviderService> logger,
                       JwtService jwtService,
                       CookieService cookieService,
                       IEmailService emailService)
        {
            _logger = logger;
            _jwtService = jwtService;
            _cookieService = cookieService;
            _emailService = emailService;
        }

        public async Task<string> AuthenticateAsync(string username, string password)
        {
            // Here you should implement your user authentication logic.
            // For this example, we'll assume a simple username/password check.
            if (username == "yadmarzan@gmail.com" && password == "123")
            {
                // Generate a token for the authenticated user
                var userId = "2246a6c9-b7ac-46a1-bc54-a52270a0668d"; // Replace with the actual user ID
                var token = _jwtService.GenerateToken(userId);

                // Set the token as a cookie for the user
                _cookieService.SetCookie("Authorization", token, expirationMinutes: 60);

                //var userContext = new UserContextBuilder().Build(Guid.Parse(userId));
                //var userContextJson = JsonConvert.SerializeObject(userContext);
                //HttpContext.Session.SetString("UserContext", userContextJson);

                //bool smsSuccess = await _clickSendSmsService.SendSmsAsync(new ClickSendSmsModel()
                //{
                //    To = "+46704926256",
                //    From = "+46769436276",
                //    Body = "Test SMS"
                //});

                //await _emailService.SendEmailAsync(new EmailDataModel()
                //{
                //    To = "yadmarzan@gmail.com",
                //    Subject = "Test Email",
                //    Body = "Test Email"
                //});

                return token;
            }

            return null; // Authentication failed
        }

        public async Task<string> ForceAuthenticateAsync(Guid userId)
        {
            // Generate a token for the authenticated user
            var token = _jwtService.GenerateToken(userId.ToString());

            // Set the token as a cookie for the user
            _cookieService.SetCookie("Authorization", token, expirationMinutes: 60);

            return token;
        }

        public async Task<string> RefreshTokenAsync()
        {
            var token = _cookieService.GetCookie("Authorization");
            if (string.IsNullOrEmpty(token))
            {
                return "Token is missing";
            }

            var userId = "2246a6c9-b7ac-46a1-bc54-a52270a0668d"; // Replace with the actual user ID.
            var newAccessToken = _jwtService.GenerateToken(userId);

            // Set the new access token in the cookie.
            _cookieService.SetCookie("Authorization", newAccessToken, expirationMinutes: 60);

            return newAccessToken;
        }

        public async Task<UserAuthenticationResponse> ValidateToken()
        {
            var token = _cookieService.GetCookie("Authorization");
            if (string.IsNullOrEmpty(token))
            {
                return new UserAuthenticationResponse() { Success = false, Error = "Token is missing" };
            }

            var userPrincipal = _jwtService.ValidateToken(token);
            if (userPrincipal == null)
            {
                return new UserAuthenticationResponse() { Success = false, Error = "Token has expired" };
            }

            return new UserAuthenticationResponse() { Success = true, Token = token };
        }

        public async Task LogoutAsync()
        {
            _cookieService.RemoveCookie("Authorization");
        }
    }
}
