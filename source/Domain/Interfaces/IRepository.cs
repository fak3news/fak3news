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
        public Task<T> Get<T>(Guid id) where T : DatabaseUnit, IModel;
        public Task<IEnumerable<T>> GetAll<T>() where T : DatabaseUnit, IModel;
        public Task<T> Create<T>(T entity) where T : DatabaseUnit, IModel;
        public Task Update<T>(T entity) where T : DatabaseUnit, IModel;
        public Task Delete<T>(T entity) where T : DatabaseUnit, IModel;
    }
}
