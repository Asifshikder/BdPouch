
using BdPouch.Service.HomeBanners;
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
    public class BannerInfoViewComponent : ViewComponent
    {
        private IHomeBannerService homeBannerService;

        public BannerInfoViewComponent(
            IHomeBannerService homeBannerService)
        {
            this.homeBannerService = homeBannerService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var setting = await homeBannerService.GetHomeBanner();
            
            return View(setting);
        }
    }
}
