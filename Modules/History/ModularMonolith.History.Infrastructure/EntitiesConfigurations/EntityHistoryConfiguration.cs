using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModularMonolith.History.Domain;
using ModularMonolith.History.Domain.Entities;

namespace ModularMonolith.History.Infrastructure.EntitiesConfigurations
{
    public class EntityHistoryConfiguration : IEntityTypeConfiguration<EntityHistory>
    {
        public void Configure(EntityTypeBuilder<EntityHistory> builder)
        {
            builder.Property(x => x.EntityName).HasMaxLength(100);
            builder.Property(x => x.EventType).HasConversion<string>();
            builder.Property(x => x.RaisedBy).HasMaxLength(50);
            builder.HasKey(x => x.Id);

        }
    }
}
