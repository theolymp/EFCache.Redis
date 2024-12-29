#region usings

using System;
using System.Diagnostics.CodeAnalysis;

#endregion

namespace EFCache.Redis
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class RedisCacheException : Exception
    {
        public RedisCacheException()
        {
        }

        public RedisCacheException(string message) : base(message)
        {
        }

        public RedisCacheException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}