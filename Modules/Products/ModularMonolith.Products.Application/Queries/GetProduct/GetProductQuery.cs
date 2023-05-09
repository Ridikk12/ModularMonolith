using System;
using MediatR;
using ModularMonolith.Products.Application.Queries.GetProduct.Responses;

namespace ModularMonolith.Products.Application.Queries.GetProduct
{
    public class GetProductQuery : IRequest<GetProductQueryResponse>
    {
        public GetProductQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
