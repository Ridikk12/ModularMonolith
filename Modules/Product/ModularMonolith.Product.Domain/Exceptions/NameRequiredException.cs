using ModularMonolith.Exceptions.Abstraction;

namespace ModularMonolith.Product.Domain.Exceptions
{
    public class NameRequiredException : DomainException
    {
        public NameRequiredException() : base("Product name is required.", 100)
        {
        }
    }
}
