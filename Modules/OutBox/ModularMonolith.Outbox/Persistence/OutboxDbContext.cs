using Microsoft.EntityFrameworkCore;
using ModularMonolith.Outbox.Entities;

namespace ModularMonolith.Outbox.Persistence
{
    public class OutboxDbContext : DbContext
    {
        public DbSet<OutBoxMessage> OutBoxMessages { get; set; }

        public OutboxDbContext(DbContextOptions<OutboxDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OutBoxMessage).Assembly);
        }
    }
}