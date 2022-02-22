using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Core.Domain.cms
{
  public  class ContactPage:BaseEntity
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }
        public string MapData { get; set; }
    }
}
