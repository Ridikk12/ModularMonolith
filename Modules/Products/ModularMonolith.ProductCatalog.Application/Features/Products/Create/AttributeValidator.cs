using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ModularMonolith.Exceptions.Abstraction.Application;
using ModularMonolith.Products.Application.Abstraction;
using ModularMonolith.Products.Domain.Exceptions;

public class AttributeValidator : IAttributeValidator
{
    private readonly IProductModuleDbContext _dbContext;

    public AttributeValidator(IProductModuleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ValidateAndThrow(Guid attributeId, List<string> selectedValues, CancellationToken cancellationToken)
    {
        var attribute = await _dbContext.Attributes.FindAsync(attributeId, cancellationToken) ??
                        throw new NotFoundException<Attribute>(attributeId);

        var validAttributeValues = attribute.Values.Select(x => x.Value).ToList();

        foreach (var value in selectedValues)
        {
            if (!validAttributeValues.Contains(value))
            {
                throw new InvalidAttributeValuesException(attributeId, value);
            }
        }
    }
}