using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModularMonolith.Product.Domain;
using ModularMonolith.Product.Domain.Entities;

namespace ModularMonolith.Product.Infrastructure.EntitiesConfigurations
{
    public class BaseEntityConfiguration : IEntityTypeConfiguration<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            builder.Property(x => x.CreatedBy).HasMaxLength(100);
        }
    }
}
