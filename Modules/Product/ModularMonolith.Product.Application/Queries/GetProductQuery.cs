using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ModularMonolith.Product.Application.Responses;

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
