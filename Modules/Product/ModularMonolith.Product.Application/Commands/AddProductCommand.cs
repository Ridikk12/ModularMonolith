using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace ModularMonolith.Product.Application.Commands
{
    public class AddProductCommand : IRequest<Guid>
    {
        public AddProductCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public string Name { get; }
        public string Description { get; }
    }
}
