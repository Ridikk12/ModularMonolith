using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModularMonolith.Infrastructure.Exceptions;
using ModularMonolith.Products.Application.Features.Manufacturers;
using ModularMonolith.Products.Application.Features.Products.Create.Requests;
using ModularMonolith.Responses;

namespace ModularMonolith.Controllers.ProductCatalog;

[ApiController]
[Authorize]
[Route("product-catalog/[controller]")]
public class ManufacturersController : ModularMonolithController
{
    private readonly IMediator _mediator;

    public ManufacturersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Create a new manufacturer
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Id of created product</returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreatedResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Products(CreateManufacturerRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CreateManufacturerCommand(
                request.Name,
                request.Code),
            cancellationToken);

        return StatusCode(StatusCodes.Status201Created, new CreatedResponse(result));
    }
}