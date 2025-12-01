using ModularMonolith.Exceptions.Abstraction.Domain;

namespace ModularMonolith.Products.Domain.Exceptions;

public class InvalidPriceException : DomainException
{
    public InvalidPriceException() : base("Price has to be more then 0", ExceptionCodes.InvalidPrice)
    {
    }
}