#region usings

using System;

#endregion

namespace EFCache.Redis
{
    [Serializable]
    public class CacheEntry
    {
        public CacheEntry(object value, string[] entitySets, TimeSpan slidingExpiration,
            DateTimeOffset absoluteExpiration)
        {
            Value = value;
            EntitySets = entitySets;
            SlidingExpiration = slidingExpiration;
            AbsoluteExpiration = absoluteExpiration;
            LastAccess = DateTimeOffset.Now;
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public CacheEntry()
        {
        }

        public DateTimeOffset AbsoluteExpiration { get; set; }

        public string[] EntitySets { get; set; }

        public DateTimeOffset LastAccess { get; set; }

        public TimeSpan SlidingExpiration { get; set; }

        public object Value { get; set; }
    }
}