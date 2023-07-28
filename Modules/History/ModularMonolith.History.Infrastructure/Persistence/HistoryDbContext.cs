using Microsoft.EntityFrameworkCore;
using ModularMonolith.History.Domain.Entities;
using ModularMonolith.History.Infrastructure.EntitiesConfigurations;
using ModularMonolith.Infrastructure.Persistence;
using ModularMonolith.Infrastructure.Services;
using ModularMonolith.Outbox.Persistence;

namespace ModularMonolith.History.Infrastructure.Persistence
{
    public class HistoryDbContext : OutboxDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("hi");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityHistoryConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<EntityHistory> EntityHistories { get; set; }

        public HistoryDbContext(DbContextOptions<HistoryDbContext> options, IUserContext userContext) : base(options,
            userContext)
        {
        }
    }
}