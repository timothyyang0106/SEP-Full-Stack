using System.Text.Json;
using ApplicationCore.Contracts.Services;
using Microsoft.Extensions.Caching.Distributed;

namespace Infrastructure.Services;

public class RedisCacheService<T> : ICacheService<T> where T : class
{
    private readonly IDistributedCache _cache;

    public RedisCacheService(IDistributedCache cache)
    {
        _cache = cache;
    }               

    public async Task<T> GetCacheValueAsync(string key)
    {
        var jsonData = await _cache.GetStringAsync(key);
        if (jsonData == null) return default(T);
        var data = JsonSerializer.Deserialize<T>(jsonData);
        return data;

    }

    public async Task<IEnumerable<T>?> GetListCacheValueAsync(string key)
    {
        var jsonData = await _cache.GetStringAsync(key);
        if (jsonData == null) return default;
        var data = JsonSerializer.Deserialize<IEnumerable<T>>(jsonData);
        return data;
    }

    public async Task SetCacheValueAsync(string key, T value, TimeSpan? absoluteExpiration = null,
        TimeSpan? slidingExpirationTime = null)
    {
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = absoluteExpiration ?? TimeSpan.FromMinutes(60),
            SlidingExpiration = slidingExpirationTime ?? TimeSpan.FromHours(1)
        };

        var jsonData = JsonSerializer.Serialize(value);
        await _cache.SetStringAsync(key, jsonData, options);
    }

    public async Task SetListCacheValueAsync(string key, List<T> value, TimeSpan? absoluteExpiration = null,
        TimeSpan? slidingExpirationTime = null)
    {
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = absoluteExpiration ?? TimeSpan.FromMinutes(60),
            SlidingExpiration = slidingExpirationTime ?? TimeSpan.FromHours(1)
        };

        var jsonData = JsonSerializer.Serialize(value);
        await _cache.SetStringAsync(key, jsonData, options);
    }
}