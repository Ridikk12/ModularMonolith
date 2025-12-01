using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModularMonolith.Products.Domain.Entities;

namespace ModularMonolith.ProductCatalog.Infrastructure.EntitiesConfigurations;

public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
{
    public void Configure(EntityTypeBuilder<ProductAttribute> builder)
    {
        builder.OwnsMany(x => x.SelectedValues, navigationBuilder => { navigationBuilder.ToJson(); });
    }
}