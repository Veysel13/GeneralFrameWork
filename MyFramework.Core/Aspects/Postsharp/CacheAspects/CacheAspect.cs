using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;

namespace MyFramework.Core.Aspects.Postsharp.CacheAspects
{
    [Serializable]
   public class CacheAspect:MethodInterceptionAspect
    {
        private Type _cacheType;
        private int _cacheByMinute;
        private ICacheManager _cacheManager;

        public CacheAspect(Type cacheType,int cacheByMinute=60)
        {
            _cacheType = cacheType;
            _cacheByMinute = cacheByMinute;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (typeof(ICacheManager).IsAssignableFrom(_cacheType)==false)
            {
                throw  new Exception("Wrong Cache Manager");
            }

            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);
            base.RuntimeInitialize(method);
        }
        //methoda girmeden önce
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            //method bilgileri
            var methodName = string.Format("{0}.{1}.{2}", args.Method.ReflectedType.Namespace,args.Method.ReflectedType.Name,args.Method.Name);
            //method arguman bilgileri
            var arguments = args.Arguments.ToList();
            //method için bir key oluşturduk
            var key = string.Format("{0}({1})", methodName,
                string.Join(",", arguments.Select(x => x != null ? x.ToString() : "<Null>")));
            //bu method cache de var mı
            if (_cacheManager.IsAdd(key))
            {
                args.ReturnValue = _cacheManager.Get<object>(key);
            }
            base.OnInvoke(args);
            //cache de yoksa return value  ye ekle
            _cacheManager.Add(key,args.ReturnValue,_cacheByMinute);
        }
    }
}
