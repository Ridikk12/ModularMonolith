using System;

namespace ModularMonolith.Products.Application.Features.Products.Get.Responses
{
    public class GetProductQueryResponse
    {
        public GetProductQueryResponse(Guid id, string name, decimal price, string currencySymbol)
        {
            Id = id;
            Name = name;
            Price = price;
            CurrencySymbol = currencySymbol;
        }
        public Guid Id { get; }
        public string Name { get; }
        public Decimal Price { get; set; }
        public string CurrencySymbol { get; set; }
    }
}
