using System;
using ModularMonolith.Domain.Entities;
using ModularMonolith.Exceptions.Abstraction;
using ModularMonolith.Products.Domain.Exceptions;

namespace ModularMonolith.Products.Domain.Entities;

public class InventoryProduct : BaseEntity
{
    public string Name { get; }
    public string Description { get; }
    public int Quantity { get; }
    public InventoryProductState State { get; private set; }
    public Location ProductLocation { get; }

    //For EF Core
    private InventoryProduct()
    {
    }

    private InventoryProduct(string name, string description, int quantity, InventoryProductState state,
        Location location)
    {
        if (quantity < 0)
            throw new ArgumentException("Quantity can't be less than 0");

        Id = new Guid();
        Name = name;
        Description = description;
        Quantity = quantity;
        State = state;
        ProductLocation = location ?? throw new ArgumentNullException(nameof(location));
    }

    public void MarkSold()
    {
        State = State switch
        {
            InventoryProductState.Sold => throw new ProductAlreadySoldException(Name),
            InventoryProductState.UnderRepair => throw new ProductAlreadySoldException(Name),
            InventoryProductState.Available or InventoryProductState.Reserved => InventoryProductState.Sold,
            _ => State
        };
    }

    public static InventoryProduct New(string name, string description, int quantity, InventoryProductState state,
        Location location) => new(name, description, quantity, state, location);
}

public enum InventoryProductState
{
    Available,
    Reserved,
    UnderRepair,
    Sold
}