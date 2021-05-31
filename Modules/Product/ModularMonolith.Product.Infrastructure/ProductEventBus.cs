using ModularMonolith.Infrastructure;
using ModularMonolith.Product.Application.EventBus;

namespace ModularMonolith.Product.Infrastructure
{
    public class ProductEventBus : InMemoryEventBus, IProductEventBus
    {
        public ProductEventBus(ProductDbContext dbContext) : base(dbContext)
        {

        }
    }

}
