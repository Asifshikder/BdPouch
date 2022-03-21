using BdPouch.Service.SiteSettings;
using BdPouch.Service.SiteSettings.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BdPouch.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SiteSettingController : Controller
    {
        private ISiteSettingService siteSettingService;

        public SiteSettingController(ISiteSettingService siteSettingService)
        {
            this.siteSettingService = siteSettingService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await siteSettingService.GetSiteSetting());
        }
        public async Task<IActionResult> CreateOrEdit(long? id)
        {
            if (id != null)
            {
                return View(await siteSettingService.GetSiteSetting());
            }
            return View(new SiteSettingViewModel() { });
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(SiteSettingViewModel model)
        {
            if (model.Id != 0)
            {
                await siteSettingService.Update(model);
            }
            else
            {
                await siteSettingService.Create(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
