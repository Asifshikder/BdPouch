using BdPouch.Core.Common;
using BdPouch.Core.Domain.cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Service.ContactPages
{
    public interface IContactPageService
    {
            Task<IEnumerable<ContactPage>> GetAllAsync();
            Task<ContactPage> GetByIdAsync(long id);
            Task<ContactPage> AddAsync(ContactPage model);
            Task<bool> UpdateAsync(ContactPage model);
            Task<int> TotalCountAsync();
            Task<bool> DeleteById(long id);
            Task<bool> DeleteAsync(ContactPage model);
            bool CheckIfExists(long id);
            Task<PagedModel<ContactPage>> GetPagedListAsync(int page, int pageSize);
    }

}

