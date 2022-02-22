using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Core.Domain.Core
{
  public  class CountryCode:BaseEntity
    {
        public string Code { get; set; }
        public string Country { get; set; }
    }
}
