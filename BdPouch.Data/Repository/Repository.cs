using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BdPouch.Data.Data;
using BdPouch.Data.Extensions;
using BdPouch.Core;
using BdPouch.Core.Domain.Auth;

namespace BdPouch.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        #region ctor
        protected readonly ProjectContext context;
        protected readonly IWorkContext workContext;

        public Repository(ProjectContext context, IWorkContext workContext)
        {
            this.context = context;
            this.workContext = workContext;
        }
        #endregion ctor
        #region methods
        public async Task<T> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var findData = await context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
            return findData;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await context.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return await context.Set<T>().CountAsync(cancellationToken);
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            try
            {
                entity = await GetAddAsyncProperties(entity);
                await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync(cancellationToken);

                return entity;
            }
            catch (Exception ex)
            {
                entity = null;
                return entity;
            }

        }

        public async Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            try
            {
                var dbentity = await GetByIdAsync(entity.Id);
                entity = await GetUpdateAsyncProperties(entity, dbentity);
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


      
        public async Task<T> FirstOrDefaultAsync(CancellationToken cancellationToken = default)
        {
            return await context.Set<T>().FirstOrDefaultAsync(cancellationToken);
        }

        public int Count()
        {
            return context.Set<T>().Count();
        }

        public async Task<IEnumerable<T>> GetAllPagedAsync(int recSkip, int recTake, CancellationToken cancellationToken = default)
        {
            return await context.Set<T>().Skip(recSkip).Take(recTake).ToListAsync(cancellationToken);
        }

        public IQueryable<T> AllAsIQueryable()
        {
            return context.Set<T>().AsQueryable();
        }
        public async Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }


        public async Task<bool> DeleteByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await context.Set<T>().FindAsync(id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }

        public bool CheckIfExist(long id)
        {
            return context.Set<T>().Any(s => s.Id == id);
        }
        #endregion

        #region properties


        private async Task<T> GetAddAsyncProperties(T entity)
        {
            ApplicationUser user = await workContext.GetCurrentUserAsync();
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = user!=null?user.Id: "5f72f83b-7436-4221-869c-1b69b2e23aae"; 
            return entity;
        }
        private async Task<T> GetUpdateAsyncProperties(T entity,T model)
        {
            ApplicationUser user = await workContext.GetCurrentUserAsync();
            entity.UpdatedOn = DateTime.Now;
            entity.CreatedBy = user != null ? user.Id : "5f72f83b-7436-4221-869c-1b69b2e23aae";
            entity.CreatedOn = model.CreatedOn;
            entity.CreatedBy = model.CreatedBy;
            return entity;
        }
        #endregion
    }
}