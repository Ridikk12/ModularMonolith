using ModularMonolith.Products.Domain.Enums;

namespace ModularMonolith.Products.Domain.ValueObjects
{
    public record Money(decimal Price, CurrencySymbol CurrencySymbol);
}