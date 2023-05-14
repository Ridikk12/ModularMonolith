using ModularMonolith.Exceptions.Abstraction;

namespace ModularMonolith.Products.Domain.Exceptions
{
    public class NameRequiredException : DomainException
    {
        public NameRequiredException() : base("Product name is required.", 100)
        {
        }
    }
}
