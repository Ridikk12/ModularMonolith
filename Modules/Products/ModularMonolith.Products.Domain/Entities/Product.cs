using System;
using ModularMonolith.Domain.Entities;
using ModularMonolith.Products.Domain.Enums;
using ModularMonolith.Products.Domain.Exceptions;
using ModularMonolith.Products.Domain.ValueObjects;

namespace ModularMonolith.Products.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; }
        public string Description { get; }
        public Money Price { get; }
        public Color Color { get; }
        public Manufacturer Manufacturer { get; private set; }


        private Product()
        {
        }

        private Product(string name, string description, Money price, Color color)
        {
            Name = name;
            Description = description;
            Price = price;
            Color = color;
            Id = Guid.NewGuid();
        }

        public static Product New(string name, string description, Money price, Color color)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new NameRequiredException();
            }

            if (price.Price < 0)
            {
                throw new InvalidPriceException();
            }


            return new Product(name, description, price, color);
        }
    }
}