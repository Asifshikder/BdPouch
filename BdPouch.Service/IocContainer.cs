using BdPouch.Service.Companies;
using BdPouch.Service.MainSeos;
using BdPouch.Service.Products;
using BdPouch.Service.SiteSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BdPouch.Service
{
    public static class IocContainer
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IMainSeoService, MainSeoService>();
            services.AddTransient<ISiteSettingService, SiteSettingService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IProductService, ProductService>();
            return services;
        }
    }
}
