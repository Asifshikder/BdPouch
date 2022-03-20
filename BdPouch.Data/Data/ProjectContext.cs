
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BdPouch.Data.Data.SeedData;
using BdPouch.Core.Domain.Auth;
using BdPouch.Core.Domain.cms;
using BdPouch.Core.Domain.Core;
using BdPouch.Core.Domain.Settings;

namespace BdPouch.Data.Data
{
    public class ProjectContext : IdentityDbContext<ApplicationUser>
    {

        public ProjectContext(DbContextOptions<ProjectContext> options)
           : base(options)
        {
        }
        public virtual DbSet<AboutUs> AboutUs { get; set; }
        public virtual DbSet<ContactPage> ContactPage { get; set; }
        public virtual DbSet<HomePage> HomePage { get; set; }
        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CountryCode> CountryCode { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<MainSeo> MainSeo { get; set; }
        public virtual DbSet<SiteSetting> SiteSetting { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            FixedData.SeedData(builder);
            base.OnModelCreating(builder);
        }

    }
}
