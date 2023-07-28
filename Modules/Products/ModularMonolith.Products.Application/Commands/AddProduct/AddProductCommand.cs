using System;
using MediatR;
using ModularMonolith.Products.Application.Commands.AddProduct.Requests;

namespace ModularMonolith.Products.Application.Commands.AddProduct
{
    public class AddProductCommand : IRequest<Guid>
    {
        public AddProductCommand(string name, string description, decimal price, ColorDto color)
        {
            Name = name;
            Description = description;
            Price = price;
            Color = color;
        }

        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public ColorDto Color { get; }
    }
}