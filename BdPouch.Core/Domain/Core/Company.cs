using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Core.Domain.Core
{
    public class Company : BaseEntity
    {
        public string CompanyName { get; set; }
        public string CompanyBrandName { get; set; }
        public string OfficeAddress { get; set; }
        public string FactoryAddressDetails { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyLogo { get; set; }
        public string ShortDescription { get; set; }
        public string Website { get; set; }
        public string FacebookUrl { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
