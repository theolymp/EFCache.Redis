#region usings

using System;

#endregion

namespace EFCache.Redis
{
    public interface IRedisCache : ICache
    {
        long Count { get; }
        event EventHandler<RedisCacheException> CachingFailed;
        void Purge();
    }
}