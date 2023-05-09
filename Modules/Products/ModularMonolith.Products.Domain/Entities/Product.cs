using ModularMonolith.Products.Domain.Exceptions;

namespace ModularMonolith.Products.Domain.Entities
{
    public class Product : BaseEntity
    {
        private Product()
        {

        }
        private Product(string name, string description, string createdBy)
        {
            Name = name;
            Description = description;
            CreatedBy = createdBy;
        }
        public string Name { get; }
        public string Description { get; }

        public static Product New(string name, string description, string createdBy)
        {
            if (string.IsNullOrEmpty(name))
                throw new NameRequiredException();

            return new Product(name, description, createdBy);
        }
    }
}
