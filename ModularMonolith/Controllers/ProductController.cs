using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModularMonolith.Product.Application.Commands;
using ModularMonolith.Product.Application.Queries;

namespace ModularMonolith.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Products(AddProductCommand request, CancellationToken token) =>
            Ok(await _mediator.Send(request, token));

        [HttpGet]
        public async Task<ActionResult> Products(Guid id, CancellationToken token) =>
            Ok(await _mediator.Send(new GetProductQuery(id), token));
    }
}
