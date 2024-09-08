using System;
using MediatR;
using ModularMonolith.Products.Application.Features.Products.Get.Responses;

namespace ModularMonolith.Products.Application.Features.Products.Get
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
