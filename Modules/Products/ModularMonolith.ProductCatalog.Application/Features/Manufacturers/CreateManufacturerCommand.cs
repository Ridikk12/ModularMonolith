using System;
using MediatR;

namespace ModularMonolith.Products.Application.Features.Manufacturers;

public record CreateManufacturerCommand(string Name, string Code) : IRequest<Guid>;