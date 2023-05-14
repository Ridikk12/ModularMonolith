using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ModularMonolith.Products.Infrastructure.EntitiesConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Products.Domain.Entities.Product>
    {
        public void Configure(EntityTypeBuilder<Products.Domain.Entities.Product> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedBy).HasMaxLength(100);
            builder.Property(x => x.Name).HasMaxLength(100);
        }
    }
}
