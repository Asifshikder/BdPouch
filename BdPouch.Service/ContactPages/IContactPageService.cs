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
        Task<ContactPage> GetContactPage();
        Task<ContactPage> Create(ContactPage model);
        Task<bool> Update(ContactPage model);
    }

}

