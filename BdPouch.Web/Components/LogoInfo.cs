
using BdPouch.Service.MainSeos;
using BdPouch.Service.SiteSettings;
using BdPouch.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BdPouch.Web.Components
{
    public class LogoInfoViewComponent : ViewComponent
    {
        private ISiteSettingService siteSettingService;

        public LogoInfoViewComponent(
            ISiteSettingService siteSettingService)
        {
            this.siteSettingService = siteSettingService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var setting = await siteSettingService.GetSiteSetting();
            
            return View(setting);
        }
    }
}
