using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BdPouch.Web.Models
{
    public class Header
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Keywords { get; set; }
        public string Tags { get; set; }
        public string SiteName { get; set; }
        public string Logo { get; set; }
        public string Favicon { get; set; }
    }
}
