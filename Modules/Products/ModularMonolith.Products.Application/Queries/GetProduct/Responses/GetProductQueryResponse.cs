using System;

namespace ModularMonolith.Products.Application.Queries.GetProduct.Responses
{
    public class GetProductQueryResponse
    {
        public GetProductQueryResponse(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public Guid Id { get; }
        public string Name { get; }
    }
}
