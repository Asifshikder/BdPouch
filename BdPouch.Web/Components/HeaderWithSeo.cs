
using BdPouch.Service.MainSeos;
using BdPouch.Service.SiteSettings;
using BdPouch.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Components
{
    public class HeaderWithSeoViewComponent : ViewComponent
    {
        private IMainSeoService mainSeoService;
        private ISiteSettingService siteSettingService;

        public HeaderWithSeoViewComponent(IMainSeoService mainSeoService,
            ISiteSettingService siteSettingService)
        {
            this.mainSeoService = mainSeoService;
            this.siteSettingService = siteSettingService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var seo = await mainSeoService.GetSeoSetup();
            var setting = await siteSettingService.GetSiteSetting();
            Header header = new Header()
            {
                SiteName = setting != null ? setting.SiteName : string.Empty,
                Author = seo != null ? seo.Author : string.Empty,
                Description = seo != null ? seo.Description : string.Empty,
                Favicon = setting != null ? setting.Favicon : string.Empty,
                Keywords = seo != null ? seo.Keywords : string.Empty,
                Tags = seo != null ? seo.Tags : string.Empty,
                Title = seo != null ? seo.Title : string.Empty,
                Logo = setting != null ? setting.Logo : string.Empty,
            };
            return View(header);
        }
    }
}
