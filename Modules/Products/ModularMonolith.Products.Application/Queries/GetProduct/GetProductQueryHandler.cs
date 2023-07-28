using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularMonolith.Exceptions.Abstraction;
using ModularMonolith.Products.Application.Queries.GetProduct.Responses;
using ModularMonolith.Products.Domain.Entities;
using ModularMonolith.Products.Domain.Interfaces;

namespace ModularMonolith.Products.Application.Queries.GetProduct
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
                throw new NotFoundException(request.Id.ToString(), nameof(Product));

            return new GetProductQueryResponse(product.Id, product.Name);
        }
    }
}