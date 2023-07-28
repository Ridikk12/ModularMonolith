using ModularMonolith.Exceptions.Abstraction;

namespace ModularMonolith.Products.Domain.Exceptions;

public class InvalidPriceException : DomainException
{
    public InvalidPriceException() : base("Price has to be more then 0", 103)
    {
    }
}