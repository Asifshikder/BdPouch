using BdPouch.Core.Common;
using BdPouch.Core.Domain.cms;
using BdPouch.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Service.HomeBanners
{
    public class HomeBannerService : IHomeBannerService
    {
        private IRepository<Banner> repository;

        public HomeBannerService(IRepository<Banner> repository)
        {
            this.repository = repository;
        }

        public async Task<Banner> Create(Banner model)
        {
            if (CheckIfAny())
            {
                return null;
            }
            return await repository.AddAsync(model);
        }
        public bool CheckIfAny()
        {
            return repository.AllAsIQueryable().Any();
        }
        public async Task<Banner> GetHomeBanner()
        {
            return await repository.FirstOrDefaultAsync();
        }

        public async Task<bool> Update(Banner model)
        {
            return await repository.UpdateAsync(model);
        }
    }
}
