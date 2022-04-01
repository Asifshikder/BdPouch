using BdPouch.Service.Companies;
using BdPouch.Service.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BdPouch.Web.Controllers
{
    public class CompanyController : Controller
    {
        private ICompanyService companyService;
        public CompanyController (ICompanyService companyService)
        {
            this.companyService = companyService;
        }
        public async  Task<IActionResult> Index()
        {
            return View( await companyService.GetAllAsync());
        }
        public async  Task<IActionResult> Details(long id)
        {
            return View(await companyService.GetByIdAsync(id));
        }
    }
}
