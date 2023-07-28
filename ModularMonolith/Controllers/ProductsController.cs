using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModularMonolith.Infrastructure.Exceptions;
using ModularMonolith.Products.Application.Commands.AddProduct;
using ModularMonolith.Products.Application.Commands.AddProduct.Requests;
using ModularMonolith.Products.Application.Queries;
using ModularMonolith.Products.Application.Queries.GetProduct;
using ModularMonolith.Products.Application.Queries.GetProduct.Responses;
using ModularMonolith.Responses;

namespace ModularMonolith.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create a new product
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Id of created product</returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreatedResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Products(AddProductRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new AddProductCommand(request.Name, request.Description, request.Price, request.Color),
                cancellationToken);
            return Ok(new CreatedResponse(result));
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Return product by id</returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(GetProductQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Products(Guid id, CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(new GetProductQuery(id), cancellationToken));
    }
}