using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Template_Web.Accelerator.Services.Storage;

public class SessionStorageService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SessionStorageService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public T Get<T>(string key)
    {
        var value = _httpContextAccessor.HttpContext.Session.GetString(key);
        return string.IsNullOrEmpty(value) ? default(T) : JsonConvert.DeserializeObject<T>(value);
    }

    public void Set<T>(string key, T value)
    {
        var serializedValue = JsonConvert.SerializeObject(value);
        _httpContextAccessor.HttpContext.Session.SetString(key, serializedValue);
    }

    public void Remove(string key)
    {
        _httpContextAccessor.HttpContext.Session.Remove(key);
    }
}

