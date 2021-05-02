using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularMonolith.History.Application.Responses;
using ModularMonolith.History.Domain.Interfaces;

namespace ModularMonolith.History.Application.Queries
{
    public class GetHistoryQueryHandler : IRequestHandler<GetHistoryQuery, List<GetHistoryQueryResponse>>
    {
        private readonly IHistoryEntityRepository _historyEntityRepository;

        public GetHistoryQueryHandler(IHistoryEntityRepository historyEntityRepository)
        {
            _historyEntityRepository = historyEntityRepository;
        }
        public async Task<List<GetHistoryQueryResponse>> Handle(GetHistoryQuery request, CancellationToken cancellationToken)
        {
            var history = await _historyEntityRepository.Get(request.EntityId, cancellationToken);
            return history.Select(x => new GetHistoryQueryResponse(x.EntityName, x.RaisedOn, x.EventType.ToString()))
                .ToList();
        }
    }
}
