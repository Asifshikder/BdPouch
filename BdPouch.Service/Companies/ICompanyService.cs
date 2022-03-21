using BdPouch.Core.Common;
using BdPouch.Core.Domain.Core;
using BdPouch.Service.Companies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Service.Companies
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllAsync();
        Task<Company> GetByIdAsync(long id);
        Task<Company> AddAsync(CompanyViewModel model);
        Task<bool> UpdateAsync(CompanyViewModel model);
        Task<int> TotalCountAsync();
        Task<bool> DeleteById(long id);
        Task<bool> DeleteAsync(Company model);
        bool CheckIfExists(long id);
        bool CheckIfExistsByName(string name);
        Task<PagedModel<Company>> GetPagedListAsync(int page, int pageSize,string terms);
        Task<CompanyViewModel> GetViewModelByIdAsync(long id);
    
    }
}
