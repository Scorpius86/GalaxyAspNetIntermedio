using Galaxy.MVC.DI.ApplicationService.Core;
using Galaxy.MVC.DI.ApplicationService.Scoped;
using Galaxy.MVC.DI.ApplicationService.Singleton;
using Galaxy.MVC.DI.ApplicationService.Transient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.MVC.DI.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDI(this IServiceCollection services)
        {
            services.AddTransient<IGuidTransientApplicationService, GuidTransientApplicationService>();
            services.AddScoped<IGuidScopedApplicationService, GuidScopedApplicationService>();
            services.AddSingleton<IGuidSingletonApplicationService, GuidSingletonApplicationService>();

            services.AddTransient<ICoreApplicationService, CoreApplicationService>();

            return services;
        }
    }
}
