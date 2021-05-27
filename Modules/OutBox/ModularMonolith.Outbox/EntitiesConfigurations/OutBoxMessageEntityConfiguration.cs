using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModularMonolith.Outbox.Entities;

namespace ModularMonolith.Outbox.EntitiesConfigurations
{
    public class OutBoxMessageConfiguration : IEntityTypeConfiguration<OutBoxMessage>
    {
        public void Configure(EntityTypeBuilder<OutBoxMessage> builder)
        {
            builder.ToTable("OutBoxMessages", "out");
            builder.HasKey(x => x.Id);
        }
    }
}
