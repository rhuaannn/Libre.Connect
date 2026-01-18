using Microsoft.Extensions.Caching.Distributed;

namespace Libre.Connect.Redis.Interface;

public interface ICaching 
{
    Task SetAsync(string key, string value);
    Task<string> GetAsync(string key);
    Task RemoveAsync(string key);
}