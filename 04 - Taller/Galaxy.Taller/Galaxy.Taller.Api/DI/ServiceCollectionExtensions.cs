using Galaxy.Taller.Api.ApplicationServices;
using Galaxy.Taller.Api.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Taller.Api.DI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDI(this IServiceCollection services)
        {
            services.AddTransient<IBrandApplicationService, BrandApplicationService>();
            services.AddTransient<IClientApplicationService, ClientApplicationService>();
            services.AddTransient<IOrderApplicationService, OrderApplicationService>();
            services.AddTransient<IProductApplicationService, ProductApplicationService>();
            services.AddTransient<IUserApplicationService, UserApplicationService>();

            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();


            return services;
        }
    }
}