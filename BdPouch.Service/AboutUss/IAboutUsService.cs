using BdPouch.Core.Domain.cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Service.AboutUss
{
    public interface IAboutUsService
    {
        Task<AboutUs> GetAboutUs();
        Task<AboutUs> Create(AboutUs model);
        Task<bool> Update(AboutUs model);
    }
}
