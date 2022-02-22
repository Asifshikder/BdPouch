using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Data.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProjectContext>
    {
        public ProjectContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectContext>();
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=bdpouchdb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new ProjectContext(optionsBuilder.Options);
        }
    }
}
