using Microsoft.EntityFrameworkCore;

namespace app_appinsightsdemo.Data
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Quote> Quotes { get; set; }
        public DbSet<IntegerResult> IntegerResult { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IntegerResult>(o => o.HasNoKey());
        }
    }
}
