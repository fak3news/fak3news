using Fak3News.Core.Domain;
using Fak3News.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fak3News.Infrastructure.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        public Task CreateAsync(Article article)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Article article)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Article> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Article>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
