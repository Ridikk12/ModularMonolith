using System;
using MediatR;

namespace ModularMonolith.Products.Application.Commands.AddProduct
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