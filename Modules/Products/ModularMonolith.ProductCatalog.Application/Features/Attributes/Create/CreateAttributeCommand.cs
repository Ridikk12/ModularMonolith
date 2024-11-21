using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularMonolith.Products.Application.Abstraction;
using ModularMonolith.Products.Domain.Entities;
using ModularMonolith.Products.Domain.Entities.Attributes;
using Attribute = ModularMonolith.Products.Domain.Entities.Attributes.Attribute;

namespace ModularMonolith.Products.Application.Features.Attributes.Create;

public record CreateAttributeCommand(string Name, List<string> Values) : IRequest<Guid>;

public class CreateAttributeCommandHandler : IRequestHandler<CreateAttributeCommand, Guid>
{
    private readonly IProductModuleDbContext _dbContext;

    public CreateAttributeCommandHandler(IProductModuleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateAttributeCommand request, CancellationToken cancellationToken)
    {
        var attribute = new Attribute
        {
            Name = request.Name,
            Values = request.Values.Select(x => new AttributeValue { Value = x}).ToList(),
            Type = AttributeType.Multiselect,
        };

        await _dbContext.Attributes.AddAsync(attribute, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return attribute.Id;
    }
}