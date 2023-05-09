using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularMonolith.Contracts;
using ModularMonolith.Infrastructure.Services;
using ModularMonolith.Products.Application.EventBus;
using ModularMonolith.Products.Domain.Entities;
using ModularMonolith.Products.Domain.Interfaces;

namespace ModularMonolith.Products.Application.Commands.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Guid>
    {
        private readonly IProductEventBus _eventBus;
        private readonly IProductRepository _productRepository;
        private readonly IUserContext _userContext;
        public AddProductCommandHandler(IProductEventBus eventBus,
            IProductRepository productRepository,
            IUserContext userContext)
        {
            _eventBus = eventBus;
            _productRepository = productRepository;
            _userContext = userContext;
        }

        public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var userId = _userContext.UserId;
            var product = Product.New(request.Name, request.Description, userId);

            await _productRepository.Add(product);

            await _eventBus.Publish(new ProductCratedIntegrationEvent(product.Id, request.Name, request.Description, userId, DateTime.UtcNow));

            await _productRepository.CommitAsync();
            return product.Id;
        }
    }
}
