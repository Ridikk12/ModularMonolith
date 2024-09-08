using System;
using System.Collections.Generic;
using ModularMonolith.Domain.Entities;
using ModularMonolith.Products.Domain.Exceptions;
using ModularMonolith.Products.Domain.ValueObjects;

namespace ModularMonolith.Products.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; }
        public string Description { get; }
        public Money Price { get; }
        public ICollection<ProductAttribute> Attributes { get; }
        public Manufacturer Manufacturer { get; }
        
        private Product(string name, string description, Money price, List<ProductAttribute> attributes,
            Manufacturer manufacturer)
        {
            Name = name;
            Description = description;
            Price = price;
            Id = Guid.NewGuid();
            Manufacturer = manufacturer;
            Attributes = attributes;
        }

        protected Product()
        {
            
        }

        public static Product New(string name, string description, Money price, Manufacturer manufacturer,
            List<ProductAttribute> attributes)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new NameRequiredException();
            }

            if (price.Price < 0)
            {
                throw new InvalidPriceException();
            }
            
            ArgumentNullException.ThrowIfNull(manufacturer);
            ArgumentNullException.ThrowIfNull(price);
            
            return new Product(name, description, price, attributes, manufacturer);
        }
    }
}