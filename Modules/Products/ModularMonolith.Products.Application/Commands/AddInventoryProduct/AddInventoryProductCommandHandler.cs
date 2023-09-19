using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModularMonolith.Exceptions.Abstraction;
using ModularMonolith.Products.Application.Abstraction;
using ModularMonolith.Products.Domain.Entities;

namespace ModularMonolith.Products.Application.Commands.AddInventoryProduct;

public class AddInventoryProductCommandHandler : IRequestHandler<AddInventoryProductCommand>
{
    private readonly IProductModuleDbContext _productDbContext;

    public AddInventoryProductCommandHandler(IProductModuleDbContext productDbContext)
    {
        _productDbContext = productDbContext;
    }
    
    public async Task<Unit> Handle(AddInventoryProductCommand request, CancellationToken cancellationToken)
    {
        var location = await _productDbContext.Locations.FirstOrDefaultAsync(x => x.Id == request.LocationId,
            cancellationToken: cancellationToken);

        if (location is null)
            throw new NotFoundException(request.LocationId.ToString(), nameof(Location));

        var inventoryProduct = InventoryProduct.New(request.Name, request.Description, request.Quantity,
            InventoryProductState.Available, location);

        _productDbContext.InventoryProducts.Add(inventoryProduct);
        await _productDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}