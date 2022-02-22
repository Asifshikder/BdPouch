using BdPouch.Core.Domain.Auth;
using BdPouch.Data.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Data.Extensions
{
    public class WorkContext : IWorkContext
    {
        private const bool IsInDevelopment = false;
        private ApplicationUser _currentUser;
        private UserManager<ApplicationUser> _userManager;
        private HttpContext _httpContext;
        private ProjectContext _uappContext;
        private SignInManager<ApplicationUser> _signInManager;

        public WorkContext(UserManager<ApplicationUser> userManager,
                           IHttpContextAccessor contextAccessor,
                           ProjectContext uappContext,
                           SignInManager<ApplicationUser> signInManager
                           )
        {
            _userManager = userManager;
            _httpContext = contextAccessor.HttpContext;
            _uappContext = uappContext;
            _signInManager = signInManager;
        }

        public async Task<ApplicationUser> GetCurrentUserAsync()
        {
            if (IsInDevelopment)
            {
                return _userManager.Users.FirstOrDefault();
            }
            else
            {
                var contextUser = _httpContext.User;
                if (contextUser != null)
                {

                _currentUser = await _userManager.GetUserAsync(contextUser);
                }
                //else
                //{
                //    var user = 
                //}
                
                if (_currentUser != null)
                {
                    return _currentUser;
                }
                return _currentUser;
            }

        }
        public async Task<bool> IsUserSignedIn()
        {
            var contextUser = _httpContext.User;
            _currentUser = await _userManager.GetUserAsync(contextUser);

            if (_currentUser != null)
            {
                return true;
            }
            else
                return false;
        }

       
    }
}