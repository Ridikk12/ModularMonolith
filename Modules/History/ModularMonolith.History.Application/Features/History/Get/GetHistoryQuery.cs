using System;
using System.Collections.Generic;
using MediatR;
using ModularMonolith.History.Application.Features.History.Get.Responses;

namespace ModularMonolith.History.Application.Features.History.Get;

public class GetHistoryQuery : IRequest<List<GetHistoryQueryResponse>>, IRequest<Unit>
{
    public GetHistoryQuery(Guid entityId)
    {
        EntityId = entityId;
    }
    public Guid EntityId { get; }
}