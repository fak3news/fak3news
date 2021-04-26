using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fak3News.Domain.Interfaces.Services;
using Fak3News.Domain.Models;
using Fak3News.Domain.Models.DbResources;
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

        public async Task<Article> Create(Article article)
        {
            await repository.CreateAsync<ArticleResource>(ToResource(article));
            return article;
        }

        public async Task<Article> Delete(Article article)
        {
            await repository.DeleteAsync(ToResource(article));
            return article;
        }

        public async Task<Article> Get(Guid id)
        {
            return ToModel(await repository.GetAsync<ArticleResource>(id));
        }

        public async Task<IEnumerable<Article>> GetAll()
        {
            List<Article> models = new List<Article>();

            foreach (var item in await repository.GetAllAsync<ArticleResource>())
            {
                models.Add(ToModel(item));
            }

            return models;
        }

        public async Task<Article> Update(Article article)
        {
            await repository.UpdateAsync(ToResource(article));
            return article;
        }

        private Article ToModel(ArticleResource resource)
        {
            Article model = new Article();

            try
            {
                var content = resource.Content.Split('\n', '.');
                var title = content.First(str => str.StartsWith('#'));
                var titleIndex = content.ToList().IndexOf(title);

                model.Title = title.Remove(title.IndexOf('#')).Trim();
                model.CreatedAt = resource.CreatedAt;
                model.Content = resource.Content;
                model.Id = resource.Id;

                if (titleIndex == 0)
                {
                    model.Description = String.Concat(content.Skip(1).Take(2));
                }
                else
                {
                    int count = titleIndex <= 2 ? titleIndex : 2;
                    model.Description = String.Concat(content.Take(count));
                }

                return model;

            }
            catch (Exception)
            {
            }

            model.Content = resource.Content;
            model.CreatedAt = resource.CreatedAt;
            model.Id = resource.Id;
            model.Description = "Undefined";
            model.Title = "Undefined";

            return model;
        }

        private ArticleResource ToResource(Article model)
        {
            return new ArticleResource()
            {
                CreatedAt = model.CreatedAt,
                Content = model.Content,
                Id = model.Id
            };
        }
    }
}
