using Fak3News.Domain.Interfaces.Services;
using Fak3News.Domain.Models;
using Fak3News.Infrastructure.Data;
using Fak3News.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ServicesTest
{
    public class AricleServiceTest
    {
        private AppDbContext context;

        public AricleServiceTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("TestDb");

            context = new AppDbContext(options.Options);
        }

        [Fact]
        public async void CreateArtice()
        {
            IArticleService articleService = new ArticleService(context);

            string uniqueString = Guid.NewGuid().ToString();

            await articleService.Create(new Article() { Content = uniqueString });

            var testItem = (await articleService.GetAll()).First(article => article.Content == uniqueString);
            Assert.NotNull(testItem);

            var dbItem = context.Articles.First(article => article.Content == uniqueString);
            Assert.Equal(dbItem.Id, testItem.Id);
        }

        [Fact]
        public async void GetArticle()
        {
            IArticleService articleService = new ArticleService(context);

            string uniqueString = Guid.NewGuid().ToString();

            await articleService.Create(new Article() { Content = uniqueString });

            var dbItem = context.Articles.First(article => article.Content == uniqueString);

            Assert.Equal(uniqueString, (await articleService.Get(dbItem.Id)).Content);
        }

        [Fact]
        public async void GetAllArticles()
        {
            IArticleService articleService = new ArticleService(context);

            for (int i = 0; i < 5; i++)
            {
                await articleService.Create(new Article() { Content = $"Test item {i}" });
            }

            var result = await articleService.GetAll();

            Assert.Equal(context.Articles.Count(), result.Count());
        }

        [Fact]
        public async void UpdateArticle()
        {
            IArticleService articleService = new ArticleService(context);

            string createString = Guid.NewGuid().ToString();

            await articleService.Create(new Article() { Content = createString });
            var testItem = (await articleService.GetAll()).First(article => article.Content == createString);

            string updateString = Guid.NewGuid().ToString();
            testItem.Content = updateString;
            testItem = await articleService.Update(testItem);

            Assert.Equal(updateString, testItem.Content);
        }

        [Fact]
        public async void DeleteArticle()
        {
            IArticleService articleService = new ArticleService(context);

            string createString = Guid.NewGuid().ToString();

            var testItem = await articleService.Create(new Article() { Content = createString });
            await articleService.Delete(testItem);

            Assert.Null(await articleService.Get(testItem.Id));
        }
    }
}
