using Microsoft.EntityFrameworkCore;
using ShoeWorkshop.Domain;
using ShoeWorkshop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShoeWorkshop.Database
{
    public class GenericDataService<T> : IDataService<T> where T : DomainModel
    {
        private readonly ShoeWorkshopDbContextFactory _contextFactory;

        public GenericDataService(ShoeWorkshopDbContextFactory contextFactory) => _contextFactory = contextFactory;

        public async Task<T> Create(T entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var createdEntity = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return createdEntity.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var entityToDelete = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
                if (entityToDelete is null) return false;
                context.Remove(entityToDelete);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Set<T>().ToListAsync();
            }
        }

        public async Task<T> GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            }
        }

        public async Task<IEnumerable<T>> GetWithInclude(params Expression<Func<T, object>>[] includeProperties)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await Include(context, includeProperties).ToListAsync();
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }
        private IQueryable<T> Include(ShoeWorkshopDbContext context, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = context.Set<T>().AsNoTracking();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
