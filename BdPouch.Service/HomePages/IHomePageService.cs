using BdPouch.Core.Common;
using BdPouch.Core.Domain.cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Service.HomePages
{
    public interface IHomePageService
    {
        Task<HomePage> GetHomePage();
        Task<HomePage> Create(HomePage model);
        Task<bool> Update(HomePage model);
    }
}
