using ModularMonolith.Domain.Entities;

namespace ModularMonolith.Products.Domain.Entities;

public class Manufacturer : BaseEntity
{
    public string Name { get; }
    public string Code { get; }

    public Manufacturer(string name, string code)
    {
        Name = name;
        Code = code;
    }

    public static Manufacturer New(string name, string code) 
        => new Manufacturer(name, code);
}