using MediatR;
using ModularMonolith.Contracts;
using ModularMonolith.Product.Application.EventBus;
using ModularMonolith.Product.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using ModularMonolith.Infrastructure;

namespace ModularMonolith.Product.Application.Commands
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
            var product = Domain.Entities.Product.New(request.Name, request.Description, userId);

            await _productRepository.Add(product);

            await _eventBus.Publish(new ProductCratedIntegrationEvent(product.Id, request.Name, request.Description, userId, DateTime.UtcNow));

            await _productRepository.CommitAsync();
            return product.Id;
        }
    }
}
