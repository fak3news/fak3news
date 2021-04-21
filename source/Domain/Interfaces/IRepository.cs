using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository
    {
        public Task<T> GetAsync<T>(Guid id) where T : DatabaseUnit, IModel;
        public Task<IEnumerable<T>> GetAllAsync<T>() where T : DatabaseUnit, IModel;
        public Task<T> CreateAsync<T>(T entity) where T : DatabaseUnit, IModel;
        public Task UpdateAsync<T>(T entity) where T : DatabaseUnit, IModel;
        public Task DeleteAsync<T>(T entity) where T : DatabaseUnit, IModel;
    }
}
