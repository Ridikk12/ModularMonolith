using System;
using System.Collections.Generic;

namespace ModularMonolith.Products.Application.Features.Attributes.Create.Dtos;

public record CreateAttributeDto(Guid Id, List<string> Values);