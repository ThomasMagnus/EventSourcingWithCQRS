using Microsoft.EntityFrameworkCore;
using WebApplication2.Infrastructure;

namespace WebApplication2.Context
{
    public class ApplicationReadContext : DbContext
    {
        public DbSet<ProductReadModel> ProductReadModel { get; set; }
        public ApplicationReadContext(DbContextOptions<ApplicationReadContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
