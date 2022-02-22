
using BdPouch.Core.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Data.Data.Core
{
    public class ProductBuilder : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasOne(t => t.Company)
                 .WithMany(t => t.Products)
                 .HasForeignKey(t => t.CompanyId)
                 .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
