using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ModularMonolith.Product.Infrastructure.EntitiesConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Domain.Entities.Product>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Product> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedBy).HasMaxLength(100);
            builder.Property(x => x.Name).HasMaxLength(100);
        }
    }
}
