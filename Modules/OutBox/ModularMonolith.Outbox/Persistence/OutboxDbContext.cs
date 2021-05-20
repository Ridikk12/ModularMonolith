using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
