﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryV2.Core.CrossCuttingConcerns.Caching {
    public interface ICacheManager {
        T Get<T>(string key);
        void Add(string key, object data, int cacheTime);
        bool IsAdded(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
        void Clear();
        List<T> GetAll<T>();
    }
}
