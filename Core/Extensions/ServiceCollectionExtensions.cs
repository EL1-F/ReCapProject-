using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    { //IServiceCollection >>apimizin service bağımlılıkarımızı eklediğimiz koleksiyondur
        public static IServiceCollection AddDependencyResolvers
            (this IServiceCollection serviceCollection,ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection); 
        }
    }
}
