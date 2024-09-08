using ModularMonolith.Exceptions.Abstraction.Domain;

namespace ModularMonolith.Products.Domain.Exceptions;

public class ProductAlreadySoldException : DomainException
{
    public ProductAlreadySoldException(string productName) : base($"Product {productName} already sold", ExceptionCodes.ProductAlreadySold)
    {
    }
}