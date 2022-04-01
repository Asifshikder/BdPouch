using BdPouch.Service.AboutUss;
using BdPouch.Service.Companies;
using BdPouch.Service.ContactPages;
using BdPouch.Service.CountryCodes;
using BdPouch.Service.HomeBanners;
using BdPouch.Service.HomePages;
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
            services.AddTransient<IHomePageService, HomePageService>();
            services.AddTransient<IHomeBannerService, HomeBannerService>();
            services.AddTransient<IContactPageService, ContactPageService>();
            services.AddTransient<IAboutUsService, AboutUsService>();
            services.AddTransient<ICountryCodeService, CountryCodeService>();
            return services;
        }
    }
}
