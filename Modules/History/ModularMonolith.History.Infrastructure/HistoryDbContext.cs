using System;
using Microsoft.EntityFrameworkCore;
using ModularMonolith.History.Domain;
using ModularMonolith.History.Domain.Entities;
using ModularMonolith.History.Infrastructure.EntitiesConfigurations;
using ModularMonolith.Outbox.Persistence;

namespace ModularMonolith.History.Infrastructure
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

        public HistoryDbContext(DbContextOptions<OutboxDbContext> options) : base(options)
        {
        }
    }
}
