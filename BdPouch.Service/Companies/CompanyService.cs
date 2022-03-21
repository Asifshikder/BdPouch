using BdPouch.Core.Common;
using BdPouch.Core.Domain.Core;
using BdPouch.Data.Extensions;
using BdPouch.Data.Repository;
using BdPouch.Service.Companies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Service.Companies
{
    public class CompanyService : ICompanyService
    {
        private IRepository<Company> repository;
        private IMediaService mediaService;

        public CompanyService(IRepository<Company> repository, IMediaService mediaService)
        {
            this.repository = repository;
            this.mediaService = mediaService;
        }
        public async Task<Company> AddAsync(CompanyViewModel model)
        {
            if (model.CompanyLogoFile != null)
                model.CompanyLogo = mediaService.UploadFile(model.CompanyLogoFile);
            Company company = new Company()
            {
                FactoryAddressDetails = model.FactoryAddressDetails,
                OfficeAddress = model.OfficeAddress,
                CompanyBrandName = model.CompanyBrandName,
                ShortDescription = model.ShortDescription,
                CompanyLogo = model.CompanyLogo,
                CompanyName = model.CompanyName,
                Email = model.Email,
                FacebookUrl = model.FacebookUrl,
                PhoneNumber = model.PhoneNumber,
                Website = model.Website,

            };
            return await repository.AddAsync(company);
        }

        public bool CheckIfExists(long id)
        {
            return repository.CheckIfExist(id);
        }

        public bool CheckIfExistsByName(string name)
        {
            return repository.AllAsIQueryable().Where(s => s.CompanyName.ToLower() == name.ToLower()).Any();
        }

        public async Task<bool> DeleteAsync(Company model)
        {
            return await repository.DeleteAsync(model);
        }

        public async Task<bool> DeleteById(long id)
        {
            return await repository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<Company> GetByIdAsync(long id)
        {
            return await repository.GetByIdAsync(id); 
        }

        public async Task<PagedModel<Company>> GetPagedListAsync(int page, int pageSize, string terms)
        {
            var firstpartquery = !string.IsNullOrEmpty(terms) ? repository.AllAsIQueryable().Where(s => s.CompanyName.Contains(terms) || s.CompanyBrandName.Contains(terms)).OrderBy(s => s.Id).AsQueryable() : repository.AllAsIQueryable().OrderBy(s => s.Id).AsQueryable();
           
            var secondpart = firstpartquery.AsQueryable();
            int resCount = secondpart.Count();
            int recSkip = (page - 1) * pageSize;
            var pagedlist = secondpart.Skip(recSkip).Take(pageSize);
            
            var pagers = new PagedList(resCount, page, pageSize);
            int FirstSerialNumber = ((page * pageSize) - pageSize) + 1;
            PagedModel<Company> pagedModel = new PagedModel<Company>()
            {
                Models = pagedlist,
                FirstSerialNumber = FirstSerialNumber,
                PagedList = pagers,
                TotalEntity = resCount
            };
            return pagedModel;
        }

        public async Task<CompanyViewModel> GetViewModelByIdAsync(long id)
        {
            var model = await repository.GetByIdAsync(id);
            CompanyViewModel company = new CompanyViewModel()
            {
                Id = model.Id,
                FactoryAddressDetails = model.FactoryAddressDetails,
                OfficeAddress = model.OfficeAddress,
                ShortDescription = model.ShortDescription,
                CompanyBrandName = model.CompanyBrandName,
                CompanyLogo = model.CompanyLogo,
                CompanyName = model.CompanyName,
                Email = model.Email,
                FacebookUrl = model.FacebookUrl,
                PhoneNumber = model.PhoneNumber,
                Website = model.Website,
                
            };
            return company;
        }

        public async Task<int> TotalCountAsync()
        {
            return await repository.CountAsync();
        }

        public async Task<bool> UpdateAsync(CompanyViewModel model)
        {
            if (model.CompanyLogoFile != null)
                model.CompanyLogo = mediaService.UpdateFile(model.CompanyLogo,model.CompanyLogoFile);
            Company company = new Company()
            {
                Id = model.Id,
                FactoryAddressDetails = model.FactoryAddressDetails,
                OfficeAddress = model.OfficeAddress,
                CompanyBrandName = model.CompanyBrandName,
                ShortDescription = model.ShortDescription,
                CompanyLogo = model.CompanyLogo,
                CompanyName = model.CompanyName,
                Email = model.Email,
                FacebookUrl = model.FacebookUrl,
                PhoneNumber = model.PhoneNumber,
                Website = model.Website,

            };
            return await repository.UpdateAsync(company);
        }
    }
}
