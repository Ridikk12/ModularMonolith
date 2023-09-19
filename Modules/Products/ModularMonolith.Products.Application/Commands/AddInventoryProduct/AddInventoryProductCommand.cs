using System;
using MediatR;

namespace ModularMonolith.Products.Application.Commands.AddInventoryProduct;

public record AddInventoryProductCommand
    (string Name, string Description, int Quantity, Guid LocationId) : IRequest;