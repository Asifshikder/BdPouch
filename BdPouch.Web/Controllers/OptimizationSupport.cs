using BdPouch.Service.Companies;
using BdPouch.Service.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BdPouch.Web.Controllers
{
    public class OptimizationSupport : Controller
    {
        private ICompanyService companyService;
        private IProductService productService;
        public OptimizationSupport(ICompanyService companyService, IProductService productService)
        {
            this.companyService = companyService;
            this.productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await companyService.GetAllAsync());
        }
        public async Task<IActionResult> Details(long id)
        {
            return View(await companyService.GetByIdAsync(id));
        }
        public async Task<IActionResult> ProductDetails(long id)
        {
            return View(await productService.GetByIdAsync(id));
        }
    }
}
