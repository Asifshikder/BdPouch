﻿using BdPouch.Core.Common;
using BdPouch.Core.Domain.Core;
using BdPouch.Data.Extensions;
using BdPouch.Data.Repository;
using BdPouch.Service.Companies;
using BdPouch.Service.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdPouch.Service.Products
{
    public class ProductService : IProductService
    {
        private IRepository<Product> repository;
        private ICompanyService companyService;
        private IMediaService mediaService;

        public ProductService(IRepository<Product> repository, ICompanyService companyService, IMediaService mediaService)
        {
            this.repository = repository;
            this.companyService = companyService;
            this.mediaService = mediaService;
        }
        public async Task<Product> AddAsync(ProductViewModel model)
        {
            if (model.ProductImageFile != null)
                model.ProductImage = mediaService.UploadFile(model.ProductImageFile);
            Product product = new Product()
            {
                EAN_13 = model.EAN_13,
                Category = model.Category,
                CompanyId = model.CompanyId,
                CountryOfOrigin = model.CountryOfOrigin,
                Feature = model.Feature,
                Weight_SKU = model.Weight_SKU,
                Packaging = model.Packaging,
                ProductImage = model.ProductImage,
                UnitPrice = model.UnitPrice,
                Title = model.Title,
                ShortDescription = model.ShortDescription,
            };
            return await repository.AddAsync(product);
        }

        public bool CheckIfExists(long id)
        {
            return repository.CheckIfExist(id);
        }


        public async Task<bool> DeleteAsync(Product model)
        {
            return await repository.DeleteAsync(model);
        }

        public async Task<bool> DeleteById(long id)
        {
            return await repository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(long id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<PagedModel<Product>> GetPagedListAsync(int page, int pageSize, long companyid, string terms)
        {
            List<Product> products = new List<Product>();
            var firstpartquery = !string.IsNullOrEmpty(terms) ? repository.AllAsIQueryable().Where(s => s.Title.Contains(terms) || s.Title.Contains(terms)).OrderBy(s => s.Id).AsQueryable() : repository.AllAsIQueryable().OrderBy(s => s.Id).AsQueryable();

            var secondpart = companyid != 0 ? firstpartquery.Where(s => s.CompanyId == companyid) : firstpartquery.AsQueryable();
            int resCount = secondpart.Count();
            int recSkip = (page - 1) * pageSize;
            var pagedlist = secondpart.Skip(recSkip).Take(pageSize);
            var pagers = new PagedList(resCount, page, pageSize);
            int FirstSerialNumber = ((page * pageSize) - pageSize) + 1;
            foreach(var item in pagedlist)
            {
                item.Company = await companyService.GetByIdAsync(item.CompanyId);
                products.Add(item);
            }
            PagedModel<Product> pagedModel = new PagedModel<Product>()
            {
                Models = products,
                FirstSerialNumber = FirstSerialNumber,
                PagedList = pagers,
                TotalEntity = resCount
            };
            return pagedModel;
        }

        public async Task<ProductViewModel> GetViewModelByIdAsync(long id)
        {
           var model = await repository.GetByIdAsync(id);
            return new ProductViewModel()
            {
                EAN_13 = model.EAN_13,
                Id = model.Id,
                Company = await companyService.GetByIdAsync(model.CompanyId),
                Category = model.Category,
                CompanyId = model.CompanyId,
                CountryOfOrigin = model.CountryOfOrigin,
                Feature = model.Feature,
                Weight_SKU = model.Weight_SKU,
                Packaging = model.Packaging,
                ProductImage = model.ProductImage,
                UnitPrice = model.UnitPrice,
                Title = model.Title,
                ShortDescription = model.ShortDescription,
            };
        }

        public async Task<int> TotalCountAsync()
        {
            return await repository.CountAsync();
        }

        public async Task<bool> UpdateAsync(ProductViewModel model)
        {
            if (model.ProductImageFile != null)
                model.ProductImage = mediaService.UpdateFile(model.ProductImage,model.ProductImageFile);
            Product product = new Product()
            {
                Id= model.Id,
                EAN_13 = model.EAN_13,
                Category = model.Category,
                CompanyId = model.CompanyId,
                CountryOfOrigin = model.CountryOfOrigin,
                Feature = model.Feature,
                Weight_SKU = model.Weight_SKU,
                Packaging = model.Packaging,
                ProductImage = model.ProductImage,
                UnitPrice = model.UnitPrice,
                Title = model.Title,
                ShortDescription = model.ShortDescription,
            };
            return await repository.UpdateAsync(product);
        }
    }
}