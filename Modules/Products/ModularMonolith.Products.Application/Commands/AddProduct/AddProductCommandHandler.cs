using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularMonolith.Contracts;
using ModularMonolith.Infrastructure.Services;
using ModularMonolith.Products.Application.Commands.AddProduct.Requests;
using ModularMonolith.Products.Application.EventBus;
using ModularMonolith.Products.Domain.Entities;
using ModularMonolith.Products.Domain.Enums;
using ModularMonolith.Products.Domain.Interfaces;
using ModularMonolith.Products.Domain.ValueObjects;

namespace ModularMonolith.Products.Application.Commands.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Guid>
    {
        private readonly IProductEventBus _eventBus;
        private readonly IProductRepository _productRepository;

        public AddProductCommandHandler(IProductEventBus eventBus,
            IProductRepository productRepository)
        {
            _eventBus = eventBus;
            _productRepository = productRepository;
        }

        public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var color = Color(request.Color);
            var product = Product.New(request.Name, request.Description,
                new Money(request.Price, CurrencySymbol.Usd), color);

            await _productRepository.Add(product);

            await _eventBus.Publish(new ProductCratedIntegrationEvent(product.Id, request.Name, request.Description));

            await _productRepository.CommitAsync();
            return product.Id;
        }

        private Color Color(ColorDto colorDto)
            => Enum.Parse<Color>(colorDto.ToString());
    }
}