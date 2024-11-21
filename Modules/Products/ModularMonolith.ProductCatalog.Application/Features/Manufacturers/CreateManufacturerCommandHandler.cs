using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularMonolith.Products.Application.Abstraction;
using ModularMonolith.Products.Domain.Entities;

namespace ModularMonolith.Products.Application.Features.Manufacturers;

public class CreateManufacturerCommandHandler : IRequestHandler<CreateManufacturerCommand, Guid>
{
    private readonly IProductModuleDbContext _dbContext;

    public CreateManufacturerCommandHandler(IProductModuleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateManufacturerCommand request, CancellationToken cancellationToken)
    {
        var manufacturer = Manufacturer.New(request.Name, request.Code);
        await _dbContext.Manufacturers.AddAsync(manufacturer, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return manufacturer.Id;
    }
}