using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Caching;
using System.Text.RegularExpressions;
using System.Linq;

namespace DictionaryV2.Core.CrossCuttingConcerns.Caching.Microsoft {
    public class MemoryCacheManager : ICacheManager {

        protected ObjectCache Cache => MemoryCache.Default;
        public void Add(string key, object data, int cacheTime = 60) {
            if (data == null)
                return;

            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now.AddMinutes(cacheTime);

            Cache.Add(new CacheItem(key, data), policy);
        }

        public void Clear() {
            foreach (var item in Cache) {
                Remove(item.Key);
            }
        }

        public T Get<T>(string key) {
            return (T)Cache[key];
        }

        public List<T> GetAll<T>() {
            return Cache.Cast<T>().ToList();
        }

        public bool IsAdded(string key) {
            return Cache.Contains(key);
        }

        public void Remove(string key) {
            Cache.Remove(key);
        }

        public void RemoveByPattern(string pattern) {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = Cache.Where(x => regex.IsMatch(x.Key)).Select(x => x.Key).ToList();

            foreach (var item in keysToRemove) {
                Remove(item);
            }
        }
    }
}
