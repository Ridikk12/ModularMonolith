using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace ModularMonolith.Product.Application.Commands
{
    public class AddProductCommand : IRequest<Guid>
    {

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
