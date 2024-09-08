using System;
using System.Collections.Generic;
using System.Linq;
using ModularMonolith.Domain.Entities;
using ModularMonolith.Exceptions.Abstraction;
using ModularMonolith.Products.Domain.Exceptions;

namespace ModularMonolith.Products.Domain.Entities;

public class InventoryProductItem : BaseEntity
{
    public InventoryProductStatus Status { get; set; }
    public string SerialNumber { get; set; }
}

public class SerializedProduct : InventoryProduct
{
    public int TotalQuantity => Items.Count;
    public int ReservedQuantity => Items.Count(x => x.Status == InventoryProductStatus.Reserved);
    public int SoldQuantity => Items.Count(x => x.Status == InventoryProductStatus.Sold);
    public int AvailableQuantity => Items.Count(x => x.Status == InventoryProductStatus.Available);
    public List<InventoryProductItem> Items { get; set; } = new();
}

public class NotSerializedProduct : InventoryProduct
{
    public int Quantity { get; set; }

    public void AdjustQuantity(int quantity)
    {
        
    }
}

public class InventoryProduct : BaseEntity
{
    public bool IsSerialized { get; set; }
    public string Name { get; }
    public string Description { get; }
    public Location ProductLocation { get; }

    //For EF Core

    protected InventoryProduct()
    {
        
    }

    private InventoryProduct(string name, string description,
        Location location)
    {
        Id = new Guid();
        Name = name;
        Description = description;
        ProductLocation = location ?? throw new ArgumentNullException(nameof(location));
    }
}

public enum InventoryProductStatus
{
    Available,
    Reserved,
    UnderRepair,
    Sold
}