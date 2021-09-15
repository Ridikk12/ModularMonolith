using MediatR;
using ModularMonolith.Exceptions.Abstraction;
using ModularMonolith.Product.Application.Responses;
using ModularMonolith.Product.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ModularMonolith.Product.Application.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductQueryResponse>
    {
        private readonly IProductRepository _productRepository;

        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<GetProductQueryResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get(request.Id, cancellationToken);

            if (product is null)
                throw new NotFoundException(request.Id.ToString(), nameof(Domain.Entities.Product));

            return new GetProductQueryResponse(product.Id, product.Name);
        }
    }
}
