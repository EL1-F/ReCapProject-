using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{ //tüm projede kullanacağımız injection
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
        

    }
}
