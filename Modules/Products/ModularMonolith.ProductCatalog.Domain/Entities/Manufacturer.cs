using ModularMonolith.Domain.Entities;

namespace ModularMonolith.Products.Domain.Entities;

public class Manufacturer : BaseEntity
{
    public string Name { get; }
    public string Code { get; }
    
    private Manufacturer()
    {
        
    }

    public Manufacturer(string name, string code)
    {
        Name = name;
        Code = code;
    }
    
    public static Manufacturer New(string name, string code) => new(name, code);
}