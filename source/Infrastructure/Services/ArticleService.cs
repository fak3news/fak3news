using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.Services;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Services
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
            return repository.Create(article);
        }

        public async Task<Article> Delete(Article article)
        {
            await repository.Delete(article);
            return article;
        }

        public Task<Article> Get(Guid id)
        {
            return repository.Get<Article>(id);
        }

        public Task<IEnumerable<Article>> GetAll()
        {
            return repository.GetAll<Article>();
        }

        public async Task<Article> Update(Article article)
        {
            await repository.Update(article);
            return article;
        }
    }
}
