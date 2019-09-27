using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Singleton
{
    public class CacheManager
    {
        private static readonly object _lock = new object();
        private static CacheManager _cacheManager;
        public object this[string key]
        {
            set => _cache[key] = value;
            get => _cache.GetValueOrDefault(key);
        }
        private Dictionary<string, object> _cache { get; set; }
        private CacheManager()
        {
            _cache = new Dictionary<string, object>();
        }
        public static CacheManager Instance
        {
            get
            {
                if (_cacheManager == null)
                {
                    lock (_lock)
                    {
                        if (_cacheManager == null)
                        {
                            _cacheManager = new CacheManager();
                        }
                    }
                }
                return _cacheManager;
            }
        }

    }

}
