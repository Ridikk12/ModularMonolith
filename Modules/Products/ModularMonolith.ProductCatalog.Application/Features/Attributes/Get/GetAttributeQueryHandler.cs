using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularMonolith.Exceptions.Abstraction.Application;
using ModularMonolith.Products.Application.Abstraction;
using ModularMonolith.Products.Application.Features.Attributes.Get.Responses;
using ModularMonolith.Products.Domain.Entities;
using ModularMonolith.Products.Domain.Entities.Attributes;

namespace ModularMonolith.Products.Application.Features.Attributes.Get;

public class GetAttributeQueryHandler : IRequestHandler<GetAttributeQuery, GetAttributeResponse>
{
    private readonly IProductModuleDbContext _dbContext;

    public GetAttributeQueryHandler(IProductModuleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetAttributeResponse> Handle(GetAttributeQuery request, CancellationToken cancellationToken)
    {
        var attribute = await _dbContext.Attributes.FindAsync(request.Id, cancellationToken)
                        ?? throw new NotFoundException<Attribute>(request.Id);

        return new GetAttributeResponse(attribute.Id, attribute.Name, attribute.Values.Select(x => x.Value).ToList());
    }
}