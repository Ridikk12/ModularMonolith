using System;
using ModularMonolith.Domain.Entities;

namespace ModularMonolith.Products.Domain.Entities;

public class Location : BaseEntity
{
    public string City { get; }
    public string Street { get; }
    public string PostalCode { get; }

    public Location(string city, string street, string postalCode)
    {
        City = city;
        Street = street;
        PostalCode = postalCode;
        Id = Guid.NewGuid();
    }

    public static Location New(string city, string street, string postalCode) =>
        new Location(city, street, postalCode);
}