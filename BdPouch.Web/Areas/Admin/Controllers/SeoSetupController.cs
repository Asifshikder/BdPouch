using BdPouch.Core.Domain.Settings;
using BdPouch.Service.MainSeos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BdPouch.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SeoSetupController : Controller
    {
        private IMainSeoService mainSeoService;

        public SeoSetupController(IMainSeoService mainSeoService)
        {
            this.mainSeoService = mainSeoService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await mainSeoService.GetSeoSetup());
        }
        public async Task<IActionResult> CreateOrEdit(long? id)
        {
            if (id != null)
            {
                return View(await mainSeoService.GetSeoSetup());
            }
            return View(new MainSeo() { });
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(MainSeo model)
        {
            if (model.Id != 0)
            {
                await mainSeoService.UpdateSeo(model);
            }
            else
            {
                await mainSeoService.CreateSeo(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
