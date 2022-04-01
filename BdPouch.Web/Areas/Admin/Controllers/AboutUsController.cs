using BdPouch.Core.Domain.cms;
using BdPouch.Data.Repository;
using BdPouch.Service.AboutUss;
using BdPouch.Service.ContactPages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BdPouch.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutUsController : Controller
    {
        private IAboutUsService AboutUsService;
        public AboutUsController(IAboutUsService AboutUsService)
        {
            this.AboutUsService = AboutUsService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await AboutUsService.GetAboutUs());
        }
        public async Task<IActionResult> CreateOrEdit(long? id)
        {
            if (id != null)
            {
                return View(await AboutUsService.GetAboutUs());
            }
            return View(new AboutUs() { });
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(AboutUs model)
        {
            if (model.Id != 0)
            {
                await AboutUsService.Update(model);
            }
            else
            {
                await AboutUsService.Create(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
