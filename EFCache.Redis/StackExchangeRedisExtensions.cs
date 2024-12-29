﻿#region usings

using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using StackExchange.Redis;

#endregion

namespace EFCache.Redis
{
    public static class StackExchangeRedisExtensions
    {
        private static byte[] Serialize<T>(T o) where T : class
        {
            if (o == null) return null;
            var binaryFormatter = new BinaryFormatter();

            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, o);
                var objectDataAsStream = memoryStream.ToArray();
                return objectDataAsStream;
            }
        }

        private static T Deserialize<T>(byte[] stream)
        {
            if (stream == null || !stream.Any()) return default;
            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream(stream))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                var result = (T)binaryFormatter.Deserialize(memoryStream);
                return result;
            }
        }

        public static T Get<T>(this IDatabase cache, string key)
        {
            var item = cache.StringGet(key);
            return Deserialize<T>(item);
        }

        public static void Set<T>(this IDatabase cache, string key, T value) where T : class
        {
            cache.StringSet(key, Serialize(value));
        }
    }
}