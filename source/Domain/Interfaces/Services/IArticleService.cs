using Fak3News.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fak3News.Domain.Interfaces.Services
{
    public interface IArticleService
    {
        public Task<Article> Get(Guid id);
        public Task<IEnumerable<Article>> GetAll();
        public Task<Article> Create(Article article);
        public Task<Article> Update(Article article);
        public Task<Article> Delete(Article article);
    }
}
