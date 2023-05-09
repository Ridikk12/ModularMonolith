using System;
using System.Collections.Generic;
using MediatR;
using ModularMonolith.History.Application.Queries.GetHistory.Responses;

namespace ModularMonolith.History.Application.Queries.GetHistory
{
    public class GetHistoryQuery : IRequest<List<GetHistoryQueryResponse>>, IRequest<Unit>
    {
        public GetHistoryQuery(Guid entityId)
        {
            EntityId = entityId;
        }
        public Guid EntityId { get; }
    }
}
