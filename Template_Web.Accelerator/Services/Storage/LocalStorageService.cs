using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Template_Web.Accelerator.Services.Storage;

public class LocalStorageService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LocalStorageService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public T Get<T>(string key)
    {
        var value = _httpContextAccessor.HttpContext.Request.Cookies[key];
        return string.IsNullOrEmpty(value) ? default(T) : JsonConvert.DeserializeObject<T>(value);
    }

    public void Set<T>(string key, T value)
    {
        var serializedValue = JsonConvert.SerializeObject(value);
        _httpContextAccessor.HttpContext.Response.Cookies.Append(key, serializedValue, new CookieOptions
        {
            IsEssential = true, // Make it essential to store in the local storage
            Expires = DateTime.Now.AddYears(1) // Set an expiration date
        });
    }

    public void Remove(string key)
    {
        _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
    }
}
