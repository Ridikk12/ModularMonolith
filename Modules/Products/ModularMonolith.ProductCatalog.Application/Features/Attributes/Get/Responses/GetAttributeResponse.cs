using System;
using System.Collections.Generic;

namespace ModularMonolith.Products.Application.Features.Attributes.Get.Responses;

public record GetAttributeResponse(Guid Id, string Name, List<string> Values);