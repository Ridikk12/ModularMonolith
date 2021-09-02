using System;
using ModularMonolith.Product.Domain.Exceptions;

namespace ModularMonolith.Product.Domain.Entities
{
    public class Product : BaseEntity
    {
        private Product()
        {

        }
        private Product(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public string Name { get; }
        public string Description { get; }

        public static Product New(string name, string description)
        {
            if (string.IsNullOrEmpty(name))
                throw new NameRequiredException();

            return new Product(name, description);
        }
    }
}
