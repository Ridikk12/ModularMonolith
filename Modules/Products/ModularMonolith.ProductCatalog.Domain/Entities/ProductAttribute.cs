using System;
using System.Collections.Generic;
using System.Linq;
using ModularMonolith.Domain.Entities;
using ModularMonolith.Products.Domain.Entities.Attributes;
using Attribute = ModularMonolith.Products.Domain.Entities.Attributes.Attribute;

namespace ModularMonolith.Products.Domain.Entities;

public class ProductAttribute : BaseEntity
{
    public Guid ProductId { get; init; }
    public Product Product { get; init; }
    public Guid AttributeId { get; init; }
    public Attribute Attribute { get; init; }
    public List<AttributeValue> SelectedValues { get; set; }

    public static ProductAttribute New(Guid attributeId, List<string> selectedValues)
    {
        return new ProductAttribute
        {
            AttributeId = attributeId,
            SelectedValues = selectedValues.Select(x => new AttributeValue { Value = x }).ToList()
        };
    }
}