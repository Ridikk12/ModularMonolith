using ModularMonolith.Outbox;
using ModularMonolith.Products.Application.EventBus;

namespace ModularMonolith.ProductCatalog.Infrastructure
{
    public class ProductsModuleEventBus : InMemoryEventBus, IProductEventBus
    {
        public ProductsModuleEventBus(ProductsModuleDbContext dbContext) : base(dbContext)
        {

        }
    }

}
