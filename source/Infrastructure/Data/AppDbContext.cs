using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
    }
}
