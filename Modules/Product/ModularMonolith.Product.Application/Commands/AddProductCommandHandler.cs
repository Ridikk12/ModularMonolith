using MediatR;
using ModularMonolith.Contracts;
using ModularMonolith.Contracts.Events;
using ModularMonolith.Product.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ModularMonolith.Product.Application.Commands
{
    class AddProductCommandHandler : IRequestHandler<AddProductCommand, Guid>
    {
        private readonly IEventBus _eventBus;
        private readonly IProductRepository _productRepository;
        public AddProductCommandHandler(IEventBus eventBus, IProductRepository productRepository)
        {
            _eventBus = eventBus;
            _productRepository = productRepository;
        }

        public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = Domain.Entities.Product.New(request.Name, request.Description);

            await _productRepository.Add(product);

            await _eventBus.Publish(new ProductCratedIntegrationEvent(product.Id, request.Name, request.Description, "", DateTime.UtcNow));

            await _productRepository.Commit();

            return product.Id;
        }
    }
}
