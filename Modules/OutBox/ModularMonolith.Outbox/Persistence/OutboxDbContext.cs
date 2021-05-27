using Microsoft.EntityFrameworkCore;
using ModularMonolith.Outbox.Entities;

namespace ModularMonolith.Outbox.Persistence
{
    public class OutboxDbContext : DbContext
    {
        public DbSet<OutBoxMessage> OutBoxMessages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.\;Database=ModularMonolith;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OutBoxMessage).Assembly);
        }
    }
}
