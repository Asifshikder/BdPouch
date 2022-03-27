using BdPouch.Core.Common;
using BdPouch.Core.Domain.cms;
using BdPouch.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Service.HomePages
{
    public class HomePageService : IHomePageService
    {
        private IRepository<HomePage> repository;

        public HomePageService(IRepository<HomePage> repository)
        {
            this.repository = repository;
        }

        public async Task<HomePage> Create(HomePage model)
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
        public async Task<HomePage> GetHomePage()
        {
            return await repository.FirstOrDefaultAsync();
        }

        public async Task<bool> Update(HomePage model)
        {
            return await repository.UpdateAsync(model);
        }
    }
}
