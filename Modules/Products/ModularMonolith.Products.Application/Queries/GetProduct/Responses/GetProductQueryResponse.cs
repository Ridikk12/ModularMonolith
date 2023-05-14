using System;

namespace ModularMonolith.Products.Application.Queries.GetProduct.Responses
{
    public class GetProductQueryResponse
    {
        public GetProductQueryResponse(Guid id, string name, string createdBy)
        {
            Id = id;
            Name = name;
            CreatedBy = createdBy;
        }
        public Guid Id { get; }
        public string Name { get; }
        public string CreatedBy { get; }
    }
}
