using BdPouch.Core.Domain.Settings;
using BdPouch.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Service.MainSeos
{
    public class MainSeoService : IMainSeoService
    {
        private IRepository<MainSeo> repository;

        public MainSeoService(IRepository<MainSeo> repository)
        {
            this.repository = repository;
        }
        public async Task<MainSeo> CreateSeo(MainSeo model)
        {
            return await repository.AddAsync(model);
        }

        public async Task<MainSeo> GetSeoSetup()
        {
            return await repository.FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateSeo(MainSeo model)
        {
            return await repository.UpdateAsync(model);
        }
    }
}
