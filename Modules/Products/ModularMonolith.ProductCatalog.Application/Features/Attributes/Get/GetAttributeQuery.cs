using System;
using MediatR;
using ModularMonolith.Products.Application.Features.Attributes.Get.Responses;

namespace ModularMonolith.Products.Application.Features.Attributes.Get;

public record GetAttributeQuery(Guid Id) : IRequest<GetAttributeResponse>;