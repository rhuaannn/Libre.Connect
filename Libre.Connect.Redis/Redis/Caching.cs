using Libre.Connect.Redis.Interface;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

namespace Libre.Connect.Redis.Redis;

public class Caching : ICaching
{
    private readonly IDistributedCache _distributedCache;
    private readonly DistributedCacheEntryOptions _options;

    public Caching(IDistributedCache distributedCache, IOptions<CacheSettings> cacheSettings)
    {
        _distributedCache = distributedCache;

        var settings = cacheSettings.Value;
        
        var absMinutes = settings.AbsoluteExpirationInMinutes;
        if (absMinutes <= 0) absMinutes = 60; 

        var sliMinutes = settings.SlidingExpirationInMinutes;
        if (sliMinutes <= 0) sliMinutes = 30;

        _options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(absMinutes),
            SlidingExpiration = TimeSpan.FromMinutes(sliMinutes)
        };
    }

    public async Task<string?> GetAsync(string key)
    {
        try 
        {
            return await _distributedCache.GetStringAsync(key);
        }
        catch 
        {
            return null; 
        }
    }

    public async Task SetAsync(string key, string value)
    {
        try
        {
            await _distributedCache.SetStringAsync(key, value, _options);
        }
        catch
        {
        }
    }

    public async Task RemoveAsync(string key)
    {
        try
        {
             await _distributedCache.RemoveAsync(key);
        }
        catch {}
       
    }
}