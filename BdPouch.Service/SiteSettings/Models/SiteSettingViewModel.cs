using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Service.SiteSettings.Models
{
    public class SiteSettingViewModel
    {
        public long Id { get; set; }
        public string SiteName { get; set; }
        public string Logo { get; set; }
        public IFormFile LogoFile { get; set; }
        public string Favicon { get; set; }
        public IFormFile FaviconFile { get; set; }
    }
}
