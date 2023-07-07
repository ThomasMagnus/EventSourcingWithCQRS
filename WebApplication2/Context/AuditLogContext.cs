using Microsoft.EntityFrameworkCore;
using WebApplication2.AuditLog;

namespace WebApplication2.Context
{
    public class AuditLogContext : DbContext
    {
        public DbSet<AuditLogEvent> AuditLogs { get; set; }

        public AuditLogContext(DbContextOptions<AuditLogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
