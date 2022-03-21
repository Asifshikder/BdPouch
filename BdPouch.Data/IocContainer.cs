using BdPouch.Core.Domain.Auth;
using BdPouch.Data.Data;
using BdPouch.Data.Extensions;
using BdPouch.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BdPouch.Data
{
    public static class IocContainer
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ProjectContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("constring"));
                option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }, ServiceLifetime.Transient);
            services.AddIdentity<ApplicationUser,IdentityRole>(
            options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<ProjectContext>().AddDefaultTokenProviders();
           
            services.AddScoped<IWorkContext, WorkContext>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddHttpContextAccessor();
            services.AddDistributedMemoryCache();
            return services;
        }
    }
}
