using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fak3News.Domain.Interfaces.Services;
using Fak3News.Domain.Models;
using Fak3News.Infrastructure.Data;

namespace Fak3News.Infrastructure.Services
{
    public class ArticleService : IArticleService
    {

        private readonly GenericRepository repository;

        public ArticleService(AppDbContext context)
        {
            repository = new GenericRepository(context);
        }

        public Task<Article> Create(Article article)
        {
            return repository.CreateAsync(article);
        }

        public async Task<Article> Delete(Article article)
        {
            await repository.DeleteAsync(article);
            return article;
        }

        public Task<Article> Get(Guid id)
        {
            return repository.GetAsync<Article>(id);
        }

        public Task<IEnumerable<Article>> GetAll()
        {
            return repository.GetAllAsync<Article>();
        }

        public async Task<Article> Update(Article article)
        {
            await repository.UpdateAsync(article);
            return article;
        }
    }
}
