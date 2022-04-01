using BdPouch.Core.Domain.Core;
using BdPouch.Service.CountryCodes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BdPouch.Web.Areas.Admin.Controllers
{
    [Area ("Admin")]
    public class CountryCodeController : Controller
    {
        private ICountryCodeService countryCodeService;
        public CountryCodeController (ICountryCodeService countryCodeService)
        {
            this.countryCodeService = countryCodeService;
        }
        public async Task<IActionResult> Index(int page = 1, int pagesize = 20, string terms = "")
        {
            if (page < 1)
                page = 1;
            var results = await countryCodeService.GetPagedListAsync(page, pagesize, terms);
            return View(results);
        }
        [HttpGet]
        public async Task<IActionResult> GetPaged(int page = 1, int pagesize = 20, string terms = "")
        {

            if (page < 1)
                page = 1;
            var results = await countryCodeService.GetPagedListAsync(page, pagesize, terms);
            return PartialView("_companypaginatedpartial", results);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CountryCode model)
        {
            var checker = countryCodeService.CheckIfExistsByName(model.Country);
            if (checker)
            {
                ModelState.AddModelError("CompanyName", "Already exists");
                return View(model);

            }
            await countryCodeService.AddAsync(model);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(long id)
        {
            var code = await countryCodeService.GetByIdAsync(id);
            return  View(code);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CountryCode model)
        {
            await countryCodeService.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var code = await countryCodeService.GetByIdAsync(id);
            if (code == null)
            {
                return NotFound();
            }

            return View(code);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var model = await countryCodeService.GetByIdAsync(id);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteConfirm(long id)
        {
            var model = await countryCodeService.DeleteById(id);
            if (model)
                return RedirectToAction(nameof(Index));
            return Redirect("/delete?id=" + id + "");
        }
    }
}
