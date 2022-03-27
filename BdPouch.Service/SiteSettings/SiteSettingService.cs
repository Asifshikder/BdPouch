using BdPouch.Core.Domain.Settings;
using BdPouch.Data.Extensions;
using BdPouch.Data.Repository;
using BdPouch.Service.SiteSettings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Service.SiteSettings
{
    public class SiteSettingService : ISiteSettingService
    {
        private IRepository<SiteSetting> repository;
        private IMediaService mediaService;

        public SiteSettingService(IRepository<SiteSetting> repository,IMediaService mediaService)
        {
            this.repository = repository;
            this.mediaService = mediaService;
        }

        public async Task<SiteSetting> Create(SiteSettingViewModel model)
        {
            if (CheckIfAny())
            {
                return null;
            }
            if (model.FaviconFile != null)
                model.Favicon = mediaService.UploadFile(model.FaviconFile);
            if(model.LogoFile!=null)
                model.Logo = mediaService.UploadFile(model.LogoFile);
            SiteSetting siteSetting = new SiteSetting()
            {
                SiteName = model.SiteName,
                Favicon = model.Favicon,
                Logo = model.Logo,
            };
            return await repository.AddAsync(siteSetting);
        }

        public bool CheckIfAny()
        {
            return repository.AllAsIQueryable().Any();
        }

        public async Task<SiteSetting> GetSiteSetting()
        {
            return await repository.FirstOrDefaultAsync();
        }

        public async Task<SiteSettingViewModel> GetSiteSettingViewModel()
        {
            var res= await repository.FirstOrDefaultAsync();
            SiteSettingViewModel model = new SiteSettingViewModel()
            {
                Favicon = res.Favicon,
                Id = res.Id,
                Logo = res.Logo,
                SiteName = res.SiteName
            };
            return model;
        }

        public async Task<bool> Update(SiteSettingViewModel model)
        {
            if (model.FaviconFile != null)
                model.Favicon = mediaService.UpdateFile(model.Favicon,model.FaviconFile);
            if (model.LogoFile != null)
                model.Logo = mediaService.UpdateFile(model.Logo,model.LogoFile);
            SiteSetting siteSetting = new SiteSetting()
            {
                Id = model.Id,
                SiteName = model.SiteName,
                Favicon = model.Favicon,
                Logo = model.Logo,
            };
            return await repository.UpdateAsync(siteSetting);
        }
    }
}
