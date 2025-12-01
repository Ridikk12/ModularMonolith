using ModularMonolith.Exceptions.Abstraction.Domain;

namespace ModularMonolith.Products.Domain.Exceptions
{
    public class NameRequiredException : DomainException
    {
        public NameRequiredException() : base("Product name is required.", ExceptionCodes.NameRequired)
        {
        }
    }
}