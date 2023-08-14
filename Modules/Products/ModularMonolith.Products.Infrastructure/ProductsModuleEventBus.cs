using ModularMonolith.Infrastructure;
using ModularMonolith.Outbox;
using ModularMonolith.Products.Application.EventBus;

namespace ModularMonolith.Products.Infrastructure
{
    public class ProductsModuleEventBus : InMemoryEventBus, IProductEventBus
    {
        public ProductsModuleEventBus(ProductsModuleDbContext dbContext) : base(dbContext)
        {

        }
    }

}
