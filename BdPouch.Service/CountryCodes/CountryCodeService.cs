using BdPouch.Core.Common;
using BdPouch.Core.Domain.Core;
using BdPouch.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Service.CountryCodes
{
    public class CountryCodeService : ICountryCodeService
    {
        private IRepository<CountryCode> repository;
        public CountryCodeService(IRepository<CountryCode> repository)
        {
            this.repository = repository;
        }

        public async Task<CountryCode> AddAsync(CountryCode model)
        {
            return await repository.AddAsync(model);
        }

        public bool CheckIfExists(long id)
        {
            return repository.CheckIfExist(id);
        }

        public bool CheckIfExistsByName(string name)
        {
            return repository.AllAsIQueryable().Where(s => s.Country == name).Any();
        }

        public async Task<bool> DeleteAsync(CountryCode model)
        {
            return await repository.DeleteAsync(model);
        }

        public async Task<bool> DeleteById(long id)
        {
            return await repository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<CountryCode>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<CountryCode> GetByIdAsync(long id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<PagedModel<CountryCode>> GetPagedListAsync(int page, int pageSize, string terms)
        {
            var firstpartquery = !string.IsNullOrEmpty(terms) ? repository.AllAsIQueryable().Where(s => s.Country.Contains(terms) || s.Code.Contains(terms)).OrderBy(s => s.Id).AsQueryable() : repository.AllAsIQueryable().OrderBy(s => s.Id).AsQueryable();

            var secondpart = firstpartquery.AsQueryable();
            int resCount = secondpart.Count();
            int recSkip = (page - 1) * pageSize;
            var pagedlist = secondpart.Skip(recSkip).Take(pageSize);

            var pagers = new PagedList(resCount, page, pageSize);
            int FirstSerialNumber = ((page * pageSize) - pageSize) + 1;
            PagedModel<CountryCode> pagedModel = new PagedModel<CountryCode>()
            {
                Models = pagedlist,
                FirstSerialNumber = FirstSerialNumber,
                PagedList = pagers,
                TotalEntity = resCount
            };
            return pagedModel;
        }

        public async Task<int> TotalCountAsync()
        {
          return await  repository.CountAsync();
        }

        public async Task<bool> UpdateAsync(CountryCode model)
        {
            return await repository.UpdateAsync(model);
        }
    }
}
