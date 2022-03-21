using BdPouch.Core.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Service.MainSeos
{
    public interface IMainSeoService
    {
        Task<MainSeo> GetSeoSetup();
        Task<MainSeo> CreateSeo(MainSeo model);
        Task<bool> UpdateSeo(MainSeo model);
    }
}
