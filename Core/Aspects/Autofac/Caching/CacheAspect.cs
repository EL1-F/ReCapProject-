using Core.CrossCuttingConcerns.Caching;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using System.Linq;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        { //ReflectedType >> namespace ini al demek + (fullname ile ) class adı 
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})"; // (x? >> null değilse) varsa bunu ekle ?? yoksa bunu ekle
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key); //return değeri cache deki değer olsun 
                return;
            }
            invocation.Proceed(); //veri tabanına gidecek
            _cacheManager.Add(key, invocation.ReturnValue, _duration); //veritabanından cache e (belleğe) ekliyor
        }
    }
}
