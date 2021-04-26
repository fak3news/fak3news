using Fak3News.Domain.Models;
using Fak3News.Domain.Models.DbResources;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Fak3News.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<ArticleResource> Articles { get; set; }
    }
}
