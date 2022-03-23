using BdPouch.Service.Companies;
using BdPouch.Service.Products;
using BdPouch.Service.Products.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace BdPouch.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private IProductService productService;
        private ICompanyService companyService;

        public ProductController(IProductService productService,
            ICompanyService companyService)
        {
            this.productService = productService;
            this.companyService = companyService;
        }
        public async Task<IActionResult> Index(int page = 1, int pagesize = 20,long company=0, string terms = "")
        {
            ViewBag.companylist = new SelectList((await companyService.GetAllAsync()).Select(s => new { Id = s.Id, Name = s.CompanyName }), "Id", "Name");

            if (page < 1)
                page = 1;
            var results = await productService.GetPagedListAsync(page, pagesize, company, terms);
            return View(results);
        }
        [HttpGet]
        public async Task<IActionResult> GetPaged(int page = 1, int pagesize = 20, long company = 0, string terms = "")
        {
            ViewBag.companylist = new SelectList((await companyService.GetAllAsync()).Select(s => new { Id = s.Id, Name = s.CompanyName }), "Id", "Name");

            if (page < 1)
                page = 1;
            var results = await productService.GetPagedListAsync(page, pagesize, company, terms);
            return PartialView("_productpaginatedpartial", results);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.companylist = new SelectList((await companyService.GetAllAsync()).Select(s => new { Id = s.Id, Name = s.CompanyName }), "Id", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            ViewBag.companylist = new SelectList((await companyService.GetAllAsync()).Select(s => new { Id = s.Id, Name = s.CompanyName }), "Id", "Name");

            await productService.AddAsync(model);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {
            ViewBag.companylist = new SelectList((await companyService.GetAllAsync()).Select(s => new { Id = s.Id, Name = s.CompanyName }), "Id", "Name");

            if (id == 0)
            {
                return NotFound();
            }

            var company = await productService.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            ViewBag.companylist = new SelectList((await companyService.GetAllAsync()).Select(s => new { Id = s.Id, Name = s.CompanyName }), "Id", "Name");


            var model = await productService.GetViewModelByIdAsync(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            ViewBag.companylist = new SelectList((await companyService.GetAllAsync()).Select(s => new { Id = s.Id, Name = s.CompanyName }), "Id", "Name");

            await productService.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            ViewBag.companylist = new SelectList((await companyService.GetAllAsync()).Select(s => new { Id = s.Id, Name = s.CompanyName }), "Id", "Name");

            var model = await productService.GetByIdAsync(id);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteConfirm(long id)
        {
            ViewBag.companylist = new SelectList((await companyService.GetAllAsync()).Select(s => new { Id = s.Id, Name = s.CompanyName }), "Id", "Name");

            var model = await productService.DeleteById(id);
            if (model)
                return RedirectToAction(nameof(Index));
            return Redirect("/delete?id=" + id + "");
        }
    }
}
