using DictionaryV2.Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DictionaryV2.Core.Aspects.PostSharp.CacheAspects {
    [Serializable]
    public class CacheAspect : MethodInterceptionAspect {

        Type _cacheType;
        int _cacheTime;
        ICacheManager _cacheManager;

        public CacheAspect(Type cacheType, int cacheTime = 60) {
            _cacheType = cacheType;
            _cacheTime = cacheTime;
        }

        public override void RuntimeInitialize(MethodBase method) {

            if (!typeof(ICacheManager).IsAssignableFrom(_cacheType)) {
                throw new Exception("Wrong Cache Manager");
            }
            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);

            base.RuntimeInitialize(method);
        }

        public override void OnInvoke(MethodInterceptionArgs args) {

            string methodName = string.Format("{0}.{1}.{2}", args.Method.ReflectedType.Namespace,
                    args.Method.ReflectedType.Name,
                    args.Method.Name);

            var arguments = args.Arguments.ToList();

            string key = string.Format("{0}({1})", methodName, string.Join(",", arguments.Select(x => x != null ? x.ToString() : "<NULL>")));

            if (_cacheManager.IsAdded(key)) {

                args.ReturnValue = _cacheManager.Get<object>(key);
            }

            base.OnInvoke(args);

            _cacheManager.Add(key, args.ReturnValue, _cacheTime);
        }
    }
}
