using BdPouch.Service.Companies;
using BdPouch.Service.Companies.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BdPouch.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }
        public async Task<IActionResult> Index(int page = 1, int pagesize = 20, string terms = "")
        {
            if (page < 1)
                page = 1;
            var results = await companyService.GetPagedListAsync(page, pagesize, terms);
            return View(results);
        }
        [HttpGet]
        public async Task<IActionResult> GetPaged(int page = 1, int pagesize = 20, string terms = "")
        {

            if (page < 1)
                page = 1;
            var results = await companyService.GetPagedListAsync(page, pagesize, terms);
            return PartialView("_companypaginatedpartial", results);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CompanyViewModel model)
        {
            var checker = companyService.CheckIfExistsByName(model.CompanyName);
            if (checker)
            {
                ModelState.AddModelError("CompanyName", "Already exists");
                return View(model);

            }
            await companyService.AddAsync(model);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var company = await companyService.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {

            var model = await companyService.GetViewModelByIdAsync(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CompanyViewModel model)
        {
            await companyService.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var model = await companyService.GetByIdAsync(id);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteConfirm(long id)
        {
            var model = await companyService.DeleteById(id);
            if (model)
                return RedirectToAction(nameof(Index));
            return Redirect("/delete?id=" + id + "");
        }

    }
}
