using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace ModularMonolith.Product.Application.Commands
{
    class AddProductCommand : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
