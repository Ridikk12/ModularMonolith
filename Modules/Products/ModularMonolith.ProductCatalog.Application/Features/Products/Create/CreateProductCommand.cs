using System;
using System.Collections.Generic;
using MediatR;
using ModularMonolith.Products.Application.Features.Attributes.Create.Dtos;

namespace ModularMonolith.Products.Application.Features.Products.Create;

public record CreateProductCommand(
    string Name,
    string Description,
    decimal Price,
    List<CreateAttributeDto> Attributes,
    Guid ManufacturerId) : IRequest<Guid>;