using BdPouch.Core.Common;
using BdPouch.Core.Domain.cms;
using BdPouch.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Service.ContactPages
{
    public class ContactPageService : IContactPageService
    {
        private IRepository<ContactPage> repository;
        public ContactPageService(IRepository<ContactPage> repository)
        {
            this.repository = repository;
        }

        public async Task<ContactPage> Create(ContactPage model)
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
        public async Task<ContactPage> GetContactPage()
        {
            return await repository.FirstOrDefaultAsync();
        }

        public async Task<bool> Update(ContactPage model)
        {
            return await repository.UpdateAsync (model);
        }
    }
}
