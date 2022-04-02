
using BdPouch.Service.MainSeos;
using BdPouch.Service.Products;
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
    public class CompanyProductsViewComponent : ViewComponent
    {
        private IProductService productService;

        public CompanyProductsViewComponent(
            IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync(long id)
        {
            var products = await productService.GetListByCompanyId(id);
            
            return View(products);
        }
    }
}
