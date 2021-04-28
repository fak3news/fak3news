using Fak3News.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Fak3News.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<Admin>
    {
        public AppDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
    }
}
