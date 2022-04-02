using BdPouch.Core.Common;
using BdPouch.Core.Domain.Core;
using BdPouch.Service.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Service.Products
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetListByCompanyId(long companyid);
        Task<Product> GetByIdAsync(long id);
        Task<Product> AddAsync(ProductViewModel model);
        Task<bool> UpdateAsync(ProductViewModel model);
        Task<int> TotalCountAsync();
        Task<bool> DeleteById(long id);
        Task<bool> DeleteAsync(Product model);
        bool CheckIfExists(long id);
        Task DeleteByCompanyId(long companyId);
        Task<PagedModel<Product>> GetPagedListAsync(int page, int pageSize,long companyid, string terms);
        Task<ProductViewModel> GetViewModelByIdAsync(long id);
    }
}
