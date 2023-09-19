using System;

namespace ModularMonolith.Products.Application.Queries.GetProduct.Responses
{
    public class GetProductQueryResponse
    {
        public GetProductQueryResponse(Guid id, string name, string color, decimal price, string currencySymbol)
        {
            Id = id;
            Name = name;
            Color = color;
            Price = price;
            CurrencySymbol = currencySymbol;
        }
        public Guid Id { get; }
        public string Name { get; }
        public string Color { get; set; }
        public Decimal Price { get; set; }
        public string CurrencySymbol { get; set; }
    }
}
