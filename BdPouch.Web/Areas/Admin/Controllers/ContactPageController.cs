using BdPouch.Core.Domain.cms;
using BdPouch.Service.ContactPages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BdPouch.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactPageController : Controller
    {
        private IContactPageService ContactPageService;
        public ContactPageController(IContactPageService ContactPageService)
        {
            this.ContactPageService = ContactPageService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await ContactPageService.GetContactPage());
        }
        public async Task<IActionResult> CreateOrEdit(long? id)
        {
            if (id != null)
            {
                return View(await ContactPageService.GetContactPage());
            }
            return View(new ContactPage() { });
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(ContactPage model)
        {
            if (model.Id != 0)
            {
                await ContactPageService.Update(model);
            }
            else
            {
                await ContactPageService.Create(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
