using System;
using System.Collections.Generic;
using ModularMonolith.Domain.Entities;
using Attribute = ModularMonolith.Products.Domain.Entities.Attributes.Attribute;

namespace ModularMonolith.Products.Domain.Entities;

public class ProductAttribute : BaseEntity
{
    public Guid ProductId { get; init; }
    public Product Product { get; init; }
    public Guid AttributeId { get; init; }
    public Attribute Attribute { get; init; }
    public List<string> SelectedValues { get; set; }

    public static ProductAttribute New(Guid attributeId, List<string> selectedValues)
    {
        return new ProductAttribute
        {
            AttributeId = attributeId,
            SelectedValues = selectedValues
        };
    }
}