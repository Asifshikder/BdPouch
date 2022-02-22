using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Core.Domain.Auth
{
    public partial class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
