using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModularMonolith.Products.Domain.Entities;

namespace ModularMonolith.Products.Infrastructure.EntitiesConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedBy).HasMaxLength(100);
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.OwnsOne(x => x.Price, p => { p.Property(x => x.Price).HasPrecision(4); });
            builder.Property(x => x.Color).HasConversion<string>();
        }
    }
}