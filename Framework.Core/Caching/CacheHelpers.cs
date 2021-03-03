using System;

namespace Framework.Core.Caching
{
    public static class CacheHelpers
    {
        public static readonly TimeSpan DefaultCacheDuration = TimeSpan.FromSeconds(30);
        

        public static string GenerateCacheKey(string Key)
        {
            return Key;
        }

    }
}
