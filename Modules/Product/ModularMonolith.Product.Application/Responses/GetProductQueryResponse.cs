using System;
using System.Collections.Generic;
using System.Text;

namespace ModularMonolith.Product.Application.Responses
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
