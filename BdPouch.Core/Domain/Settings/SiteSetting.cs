using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Core.Domain.Settings
{
    public class SiteSetting : BaseEntity
    {
        public string SiteName { get; set; }
        public string Logo { get; set; }
        public string Favicon { get; set; }
    }
}
