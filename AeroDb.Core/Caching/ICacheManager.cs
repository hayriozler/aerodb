using System;
using System.Threading.Tasks;

namespace AeroDb.Core.Caching
{
    public interface ICacheManager
    {
        Task<T> GetAsync<T>(string key, Func<Task<T>> acquire);
        Task SetAsync(string key, object data, int cacheTime);
        Task RemoveAsync(string key, bool publisher);
        Task RemoveByPrefixAsync(string prefix, bool publisher);
        Task ClearAsync();

    }
}
