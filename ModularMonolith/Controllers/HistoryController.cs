using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModularMonolith.History.Application.Queries;
using ModularMonolith.History.Application.Queries.GetHistory;
using ModularMonolith.History.Application.Queries.GetHistory.Responses;
using ModularMonolith.Infrastructure.Exceptions;

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
        
        /// <summary>
        /// Get history of the entity
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<GetHistoryQueryResponse>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{entityId}")]
        public async Task<ActionResult> History(Guid entityId, CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(new GetHistoryQuery(entityId), cancellationToken));
    }
}
