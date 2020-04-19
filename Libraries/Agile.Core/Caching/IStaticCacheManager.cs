﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Core.Caching
{
    public interface IStaticCacheManager : ICacheManager
    {
        /// <summary>
        /// Get a cached item. If it's not in the cache yet, then load and cache it
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Cache key</param>
        /// <param name="acquire">Function to load item if it's not in the cache yet</param>
        /// <returns>The cached value associated with the specified key</returns>
        Task<T> GetAsync<T>(CacheKey key, Func<Task<T>> acquire);
    }
}
