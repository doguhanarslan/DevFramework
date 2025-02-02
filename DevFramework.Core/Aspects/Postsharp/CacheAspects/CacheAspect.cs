﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;
using PostSharp.Serialization;
using System.Runtime.Caching;

namespace DevFramework.Core.Aspects.Postsharp.CacheAspects
{
    [PSerializable]
    public class CacheAspect:MethodInterceptionAspect
    {
        private Type _cacheType;
        private int _cacheByMinute;
        private ICacheManager _cacheManager;
        
        public CacheAspect(Type cacheType, int cacheByMinute = 60)
        {
            _cacheType = cacheType;
            _cacheByMinute = cacheByMinute;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (typeof(ICacheManager).IsAssignableFrom(_cacheType) == false)
            {
                throw new Exception("Wrong cache manager");
            }

            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);
            base.RuntimeInitialize(method);
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            if (args.Method.ReflectedType != null)
            {
                var methodName = string.Format("{0}.{1}.{2}",
                    args.Method.ReflectedType.Namespace, args.Method.ReflectedType.Name, args.Method.Name);
                var arguments = args.Arguments.ToList();
                var key = string.Format("{0}({1})", methodName,
                    string.Join(",", arguments.Select(x => x != null ? x.ToString() : "<Null>")));

                if (_cacheManager.IsAdd(key))
                {
                    args.ReturnValue = _cacheManager.Get<object>(key);
                }
                _cacheManager.Add(key,args.ReturnValue,_cacheByMinute);
            }

            base.OnInvoke(args);
        }
    }
}
