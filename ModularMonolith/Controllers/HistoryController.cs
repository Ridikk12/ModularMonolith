using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModularMonolith.History.Application.Queries;

namespace ModularMonolith.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{entityId}")]
        public async Task<ActionResult> History(Guid entityId, CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(new GetHistoryQuery(entityId), cancellationToken));
    }
}
