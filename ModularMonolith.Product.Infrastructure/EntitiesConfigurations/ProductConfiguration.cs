using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ModularMonolith.Product.Infrastructure
{
    public class ProductConfiguration : IEntityTypeConfiguration<Domain.Product>
    {
        public void Configure(EntityTypeBuilder<Domain.Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.Property(x => x.Name).HasMaxLength(100);

        }
    }
}
