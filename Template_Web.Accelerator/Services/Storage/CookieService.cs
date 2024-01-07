using Microsoft.AspNetCore.Http;

namespace Template_Web.Accelerator.Services.Storage;

public class CookieService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CookieService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void SetCookie(string key, string value, int? expirationMinutes = null)
    {
        var options = new CookieOptions
        {
            IsEssential = true, // Make it essential to store the cookie
        };

        if (expirationMinutes.HasValue)
        {
            options.Expires = DateTime.Now.AddMinutes(expirationMinutes.Value);
        }

        _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, options);
    }

    public string GetCookie(string key)
    {
        return _httpContextAccessor.HttpContext.Request.Cookies[key];
    }

    public void RemoveCookie(string key)
    {
        _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
    }
}
