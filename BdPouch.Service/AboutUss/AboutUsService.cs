using BdPouch.Core.Domain.cms;
using BdPouch.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Service.AboutUss
{
    public class AboutUsService : IAboutUsService
    {
        private IRepository<AboutUs> repository;
        public AboutUsService(IRepository<AboutUs> repository)
        {
            this.repository = repository;
        }
        public async Task<AboutUs> Create(AboutUs model)
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

        public async Task<AboutUs> GetAboutUs()
        {
            return await  repository.FirstOrDefaultAsync();
        }

        public async Task<bool> Update(AboutUs model)
        {
            return await repository.UpdateAsync(model);
        }
    }
}
