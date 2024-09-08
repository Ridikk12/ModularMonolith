using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularMonolith.Contracts;
using ModularMonolith.Exceptions.Abstraction.Application;
using ModularMonolith.Products.Application.Abstraction;
using ModularMonolith.Products.Application.EventBus;
using ModularMonolith.Products.Domain.Entities;
using ModularMonolith.Products.Domain.Enums;
using ModularMonolith.Products.Domain.ValueObjects;

namespace ModularMonolith.Products.Application.Features.Products.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductEventBus _eventBus;
        private readonly IProductModuleDbContext _dbContext;

        public CreateProductCommandHandler(IProductEventBus eventBus, IProductModuleDbContext dbContext)
        {
            _eventBus = eventBus;
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var manufacturer = await _dbContext.Manufacturers
                                   .FindAsync(request.ManufacturerId, cancellationToken)
                               ?? throw new NotFoundException<Manufacturer>(request.ManufacturerId);


            var product = Product.New(request.Name, request.Description,
                new Money(request.Price, CurrencySymbol.Usd), manufacturer,
                request.Attributes.Select(x => ProductAttribute.New(x.Id, x.Values)).ToList());

            await _dbContext.Products.AddAsync(product, cancellationToken);

            await _eventBus.Publish(new ProductCratedIntegrationEvent(product.Id, request.Name, request.Description));
            await _dbContext.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}