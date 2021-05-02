using System;
using System.Collections.Generic;
using MediatR;
using ModularMonolith.History.Application.Responses;

namespace ModularMonolith.History.Application.Queries
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
