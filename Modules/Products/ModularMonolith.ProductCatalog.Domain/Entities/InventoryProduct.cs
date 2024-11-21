using System;
using System.Collections.Generic;
using ModularMonolith.Domain.Entities;

namespace ModularMonolith.Products.Domain.Entities;

public class SKU : BaseEntity
{
    public string Value { get; set; }
}



public record Sku(string Value);

public class InventoryProduct
{
    public string Name { get; set; }
    public string Description { get; set; }
}

public class Stock : BaseEntity
{
    public string Name { get; set; }
    public ICollection<StockProduct> StockProducts { get; set; }
}

public class StockProduct : BaseEntity
{
    public Stock Stock { get; init; }
    public Guid StockId { get; init; }
    public string SKU { get; set; }

    public static SerializedStockProduct NewSerializedProduct(string serialNumber, Stock stock, string sku)
    {
        return new SerializedStockProduct
        {
            SerialNumber = serialNumber,
            Stock = stock
        };
    }

    public static NotSerializedStockProduct NewNotSerializedProduct(int quantity, Stock stock, string sku)
    {
        return new NotSerializedStockProduct
        {
            Quantity = quantity,
            Stock = stock,
            SKU = sku
        };
    }
}

public class SerializedStockProduct : StockProduct
{
    public InventoryProductStatus Status { get; set; }
    public string SerialNumber { get; set; }
}

public class NotSerializedStockProduct : StockProduct
{
    public int Quantity { get; set; }
}

public class InventoryProductItem : BaseEntity
{
    public InventoryProductStatus Status { get; set; }
    public string SerialNumber { get; set; }
}

public enum InventoryProductStatus
{
    Available,
    Reserved,
    UnderRepair,
    Sold
}