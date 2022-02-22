using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Core.Domain.Core
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ProductImage { get; set; }
        public string Weight_SKU { get; set; }
        public string Feature { get; set; }
        public string Category { get; set; }
        public string Packaging { get; set; }
        public decimal UnitPrice { get; set; }
        public string EAN_13 { get; set; }
        public string CountryOfOrigin { get; set; }
        public long CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
