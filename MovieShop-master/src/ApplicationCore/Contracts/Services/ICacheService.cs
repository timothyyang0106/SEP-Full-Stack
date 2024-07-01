namespace ApplicationCore.Contracts.Services;

public interface ICacheService<T> where T: class
{
    Task<T> GetCacheValueAsync(string key);
    Task<IEnumerable<T>?> GetListCacheValueAsync(string key);
    Task SetCacheValueAsync (string key, T value, TimeSpan? absoluteExpiration = null, TimeSpan? slidingExpirationTime = null);
    Task SetListCacheValueAsync (string key, List<T> value, TimeSpan? absoluteExpiration = null, TimeSpan? slidingExpirationTime = null);

}