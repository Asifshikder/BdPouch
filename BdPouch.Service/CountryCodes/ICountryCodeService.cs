using BdPouch.Core.Common;
using BdPouch.Core.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Service.CountryCodes
{
    public interface ICountryCodeService
    {
        Task<IEnumerable<CountryCode>> GetAllAsync();
        Task<CountryCode> GetByIdAsync(long id);
        Task<CountryCode> AddAsync(CountryCode model);
        Task<bool> UpdateAsync(CountryCode model);
        Task<int> TotalCountAsync();
        Task<bool> DeleteById(long id);
        Task<bool> DeleteAsync(CountryCode model);
        bool CheckIfExists(long id);
        bool CheckIfExistsByName(string name);
        Task<PagedModel<CountryCode>> GetPagedListAsync(int page, int pageSize, string terms);
    }
}
