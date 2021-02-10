using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace Core.Domain.Caching
{
    public class MemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache _cache;
        private readonly IMediator _mediator;
        private readonly int _CacheInMinutes = 1;

        private CancellationTokenSource _cancellationTokenSource;

        private static readonly ConcurrentDictionary<string, bool> _allKeys;

        static MemoryCacheManager()
        {
            _allKeys = new ConcurrentDictionary<string, bool>();
        }
        public MemoryCacheManager(IMemoryCache cache, IMediator mediator)
        {
            _cache = cache;
            _mediator = mediator;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        protected MemoryCacheEntryOptions GetMemoryCacheEntryOptions(int cacheTime)
        {
            var options = new MemoryCacheEntryOptions()
                .AddExpirationToken(new CancellationChangeToken(_cancellationTokenSource.Token))
                .RegisterPostEvictionCallback(PostEviction);
            options.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(cacheTime);

            return options;
        }
        private string AddKey(string key)
        {
            _allKeys.TryAdd(key, true);
            return key;
        }
        private string RemoveKey(string key)
        {
            TryRemoveKey(key);
            return key;
        }
        private void TryRemoveKey(string key)
        {
            if (!_allKeys.TryRemove(key, out _))
                _allKeys.TryUpdate(key, false, true);
        }
        private void ClearKeys()
        {
            foreach (var key in _allKeys.Where(p => !p.Value).Select(p => p.Key).ToList())
            {
                RemoveKey(key);
            }
        }

        private void PostEviction(object key, object value, EvictionReason reason, object state)
        {
            if (reason == EvictionReason.Replaced)
                return;
            ClearKeys();
            TryRemoveKey(key.ToString());
        }

        public async Task<T> GetAsync<T>(string key, Func<Task<T>> acquire)
        {
            return await _cache.GetOrCreateAsync(key, entry =>
            {
                AddKey(key);
                entry.SetOptions(GetMemoryCacheEntryOptions(_CacheInMinutes));
                return acquire();
            });
        }

        public virtual Task SetAsync(string key, object data, int cacheTime)
        {
            if (data != null)
            {
                _cache.Set(AddKey(key), data, GetMemoryCacheEntryOptions(cacheTime));
            }
            return Task.CompletedTask;
        }

        public Task RemoveAsync(string key, bool publisher)
        {
            _cache.Remove(RemoveKey(key));
            if (publisher)
                _mediator.Publish(new EntityCacheEvent(key, CacheEvent.RemoveKey));

            return Task.CompletedTask;
        }
        public Task RemoveByPrefix(string prefix, bool publisher)
        {
            var keysToRemove = _allKeys.Keys.Where(x => x.ToString().StartsWith(prefix, StringComparison.OrdinalIgnoreCase)).ToList();
            foreach (var key in keysToRemove)
            {
                _cache.Remove(RemoveKey(key));
            }
            if (publisher)
                _mediator.Publish(new EntityCacheEvent(prefix, CacheEvent.RemovePrefix));

            return Task.CompletedTask;
        }

        public Task RemoveByPrefixAsync(string prefix, bool publisher)
        {
            if (publisher)
                _mediator.Publish(new EntityCacheEvent(prefix, CacheEvent.RemovePrefix));

            return RemoveByPrefix(prefix, publisher);
        }

        public Task ClearAsync()
        {
            _cancellationTokenSource.Cancel();

            _cancellationTokenSource.Dispose();

            _cancellationTokenSource = new CancellationTokenSource();

            return Task.CompletedTask;
        }

      
    }
}
