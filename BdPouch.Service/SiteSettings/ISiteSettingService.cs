using BdPouch.Core.Domain.Settings;
using BdPouch.Service.SiteSettings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Service.SiteSettings
{
    public interface ISiteSettingService
    {
        Task<SiteSetting> GetSiteSetting();
        Task<SiteSettingViewModel> GetSiteSettingViewModel();
        Task<SiteSetting> Create(SiteSettingViewModel model);
        Task<bool> Update(SiteSettingViewModel model);
    }
}
