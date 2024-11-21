using System;
using System.Collections.Generic;

namespace ModularMonolith.Products.Application.Features.Products.Create.Requests;
public record CreateProductRequest(string Name, string Description, decimal Price, List<AttributeRequest> Attributes, Guid ManufacturerId);

public record AttributeRequest(Guid Id, List<string> SelectedValues);

public record CreateManufacturerRequest(string Name, string Code);