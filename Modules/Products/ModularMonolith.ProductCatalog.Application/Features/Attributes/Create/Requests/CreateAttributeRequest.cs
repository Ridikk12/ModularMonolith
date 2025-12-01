using System.Collections.Generic;

namespace ModularMonolith.Products.Application.Features.Attributes.Create.Requests;

public record CreateAttributeRequest(string Name, List<string> Values);