using Fak3News.Domain.Interfaces;
using Fak3News.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fak3News.Infrastructure.Data
{
    class GenericRepository : IRepository
    {
        private readonly AppDbContext context;

        public GenericRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<T> CreateAsync<T>(T entity) where T : DatabaseUnit, IModel
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public Task DeleteAsync<T>(T entity) where T : DatabaseUnit, IModel
        {
            context.Set<T>().Remove(entity);
            return context.SaveChangesAsync();
        }

        public Task<T> GetAsync<T>(Guid id) where T : DatabaseUnit, IModel
        {
            return context.Set<T>().SingleOrDefaultAsync(item => item.Id == id);
        }

        public Task<IEnumerable<T>> GetAllAsync<T>() where T : DatabaseUnit, IModel
        {
            return Task.Run<IEnumerable<T>>(() =>
            {
                return context.Set<T>();
            });
        }

        public Task UpdateAsync<T>(T entity) where T : DatabaseUnit, IModel
        {
            context.Entry(entity).State = EntityState.Modified;
            return context.SaveChangesAsync();
        }
    }
}
