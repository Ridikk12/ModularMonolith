using System.Collections.Generic;
using ModularMonolith.Domain.Entities;

namespace ModularMonolith.Products.Domain.Entities.Attributes;

public class Attribute : BaseEntity
{
    public AttributeType Type { get; set; }
    public string Name { get; set; }
    public ICollection<AttributeValue> Values { get; set; }
}