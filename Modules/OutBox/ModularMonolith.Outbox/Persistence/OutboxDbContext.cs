using Microsoft.EntityFrameworkCore;
using ModularMonolith.Infrastructure.Persistence;
using ModularMonolith.Infrastructure.Services;
using ModularMonolith.Outbox.Entities;

namespace ModularMonolith.Outbox.Persistence
{
    public class OutboxDbContext : BaseDbContext
    {
        public DbSet<OutBoxMessage> OutBoxMessages { get; set; }

        protected OutboxDbContext(DbContextOptions options, IUserContext userContext) : base(options,
            userContext)
        {
        }
        
        public OutboxDbContext(DbContextOptions<OutboxDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OutBoxMessage).Assembly);
        }
    }
}