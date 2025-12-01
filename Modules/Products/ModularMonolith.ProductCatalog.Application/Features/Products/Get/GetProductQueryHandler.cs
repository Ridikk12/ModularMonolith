using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularMonolith.Exceptions.Abstraction.Application;
using ModularMonolith.Products.Application.Abstraction;
using ModularMonolith.Products.Application.Features.Products.Get.Responses;
using ModularMonolith.Products.Domain.Entities;

namespace ModularMonolith.Products.Application.Features.Products.Get;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductQueryResponse>
{
    private readonly IProductModuleDbContext _dbContext;

    public GetProductQueryHandler(IProductModuleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetProductQueryResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _dbContext.Products.FindAsync(request.Id, cancellationToken);

        if (product is null)
        {
            throw new NotFoundException<Product>(request.Id);
        }

        return new GetProductQueryResponse(product.Id, product.Name, product.Price.Price,
            product.Price.CurrencySymbol.ToString());
    }
}