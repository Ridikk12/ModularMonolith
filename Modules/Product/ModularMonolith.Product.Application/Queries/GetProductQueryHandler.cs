using MediatR;
using ModularMonolith.Exceptions.Abstraction;
using ModularMonolith.Product.Application.Responses;
using ModularMonolith.Product.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using ModularMonolith.User.Contracts;

namespace ModularMonolith.Product.Application.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductQueryResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserService _userModuleService;
        private readonly IUserApi _userApi;

        public GetProductQueryHandler(IProductRepository productRepository, IUserService userModuleService, IUserApi userApi)
        {
            _productRepository = productRepository;
            _userModuleService = userModuleService;
            _userApi = userApi;
        }
        public async Task<GetProductQueryResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get(request.Id, cancellationToken);

            if (product is null)
                throw new NotFoundException(request.Id.ToString(), nameof(Domain.Entities.Product));

            //User by direct reference
            var user = await _userModuleService.GetUserDetails(product.CreatedBy);

            //User by Http request
            var user2 = await _userApi.GetUserDetails(product.CreatedBy);

            return new GetProductQueryResponse(product.Id, product.Name, user.FullName);
        }
    }
}
