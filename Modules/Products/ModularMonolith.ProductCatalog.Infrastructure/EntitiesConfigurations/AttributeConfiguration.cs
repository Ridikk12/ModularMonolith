using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModularMonolith.Products.Domain.Entities.Attributes;

namespace ModularMonolith.ProductCatalog.Infrastructure.EntitiesConfigurations;

public class AttributeConfiguration : IEntityTypeConfiguration<Attribute>
{
    public void Configure(EntityTypeBuilder<Attribute> builder)
    {
        builder.HasKey(x => x.Id);
        builder.OwnsMany(x=> x.Values, navigationBuilder =>
        {
            navigationBuilder.ToJson();
        });

    }
}