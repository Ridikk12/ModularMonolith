using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularMonolith.Contracts;
using ModularMonolith.Product.Domain;
using ModularMonolith.Product.Domain.Interfaces;

namespace ModularMonolith.Product.Application.Commands
{
    class AddProductCommandHandler : IRequestHandler<AddProductCommand, Guid>
    {
        private readonly IMediator _mediator;
        private readonly IProductRepository _productRepository;

        public AddProductCommandHandler(IMediator mediator, IProductRepository productRepository)
        {
            _mediator = mediator;
            _productRepository = productRepository;
        }

        public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = Domain.Entities.Product.New(request.Name, request.Description);

            await _productRepository.Add(product);

            await _mediator.Publish(new ProductCratedEvent(product.Id, request.Name, request.Description, "", DateTime.UtcNow), CancellationToken.None);
            return product.Id;
        }
    }
}
