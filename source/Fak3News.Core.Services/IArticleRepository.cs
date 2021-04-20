using Fak3News.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fak3News.Core.Services
{
    public interface IArticleRepository
    {
        public Task CreateAsync(Article article);
        public Task UpdateAsync(Article article);
        public Task DeleteAsync(Guid id);
        public Task<IEnumerable<Article>> GetAllAsync();
        public Task<Article> GetAsync(Guid id);
    }
}
