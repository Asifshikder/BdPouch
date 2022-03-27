using BdPouch.Core.Domain.cms;
using BdPouch.Service.HomePages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BdPouch.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomePageController : Controller
    {
        private IHomePageService homePageService;

        public HomePageController(IHomePageService homePageService)
        {
            this.homePageService = homePageService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await homePageService.GetHomePage());
        }


        public async Task<IActionResult> CreateOrEdit(long? id)
        {
            if (id != null)
            {
                return View(await homePageService.GetHomePage());
            }
            return View(new HomePage() { });
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(HomePage model)
        {
            if (model.Id != 0)
            {
                await homePageService.Update(model);
            }
            else
            {
                await homePageService.Create(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
