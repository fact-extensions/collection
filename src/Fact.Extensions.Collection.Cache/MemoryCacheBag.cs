﻿using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fact.Extensions.Serialization;

namespace Fact.Extensions.Collection.Cache
{
    public class MemoryCacheBag : IBag, ITryGetter
    {
        // serializationManager is a NOOP right now and should be null
        readonly ISerializationManager serializationManager;
        readonly IMemoryCache cache;

        public event Action<ICacheEntry> CreatingEntry;

        public MemoryCacheBag(ISerializationManager serializationManager, IMemoryCache cache)
        {
            this.serializationManager = serializationManager;
            this.cache = cache;
        }

        public object Get(string key, Type type)
        {
            return cache.Get(key);
        }

        public bool TryGet(string key, Type type, out object value)
        {
            return cache.TryGetValue(key, out value);
        }

        public void Set(string key, object value, Type type)
        {
            using (var cacheEntry = cache.CreateEntry(key))
            {
                CreatingEntry?.Invoke(cacheEntry);
                cacheEntry.SetSlidingExpiration(TimeSpan.FromSeconds(120));
                cacheEntry.SetValue(value);
            }
        }
    }
}
