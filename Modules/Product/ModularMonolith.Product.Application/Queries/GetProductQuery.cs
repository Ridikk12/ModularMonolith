using MediatR;
using ModularMonolith.Product.Application.Responses;
using System;

namespace ModularMonolith.Product.Application.Queries
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
