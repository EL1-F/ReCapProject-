using Core.CrossCuttingConcerns.Caching;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.IoC;
using Castle.DynamicProxy;

namespace Core.Aspects.Autofac.Caching
{ //datamız bozulduğunda>> yeni data eklendiğinde data güncellenir ya da silinirse >> kullanılır
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        { //metot başarılı olursa _pattern e göre sil
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
