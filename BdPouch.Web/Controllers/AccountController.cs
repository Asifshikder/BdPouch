using BdPouch.Core.Domain.Auth;
using BdPouch.Data.Extensions;
using BdPouch.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BdPouch.Web.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private IWorkContext workContext;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IWorkContext workContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.workContext = workContext;
        }
        public IActionResult Login(string returnUrl)
        {
            if (signInManager.IsSignedIn(User))
            {
                var cuser = workContext.GetCurrentUserAsync().Result;
                if (cuser == null)
                {
                    return RedirectToAction(nameof(Logout));
                }
                return RedirectToAction("Index", "Home");

            }
            var model = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login)
        {

            var user = await userManager.FindByEmailAsync(login.Email);
            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, login.Password, false, false);
                if (result.Succeeded)
                {
                    if (login.ReturnUrl == null)
                    {
                        return Redirect("/Home/Index");
                    }
                    return Redirect(login.ReturnUrl);
                }
                if (result.IsNotAllowed)
                {
                    ModelState.AddModelError("IncorrectInput", "Email is not verified.");
                    return View(login);
                }

            }
            ModelState.AddModelError("IncorrectInput", "User not found!");
            return View(login);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            if (signInManager.IsSignedIn(User))
            {
                await signInManager.SignOutAsync();
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
