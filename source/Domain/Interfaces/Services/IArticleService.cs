using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
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
