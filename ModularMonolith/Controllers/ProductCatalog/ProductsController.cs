using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModularMonolith.Infrastructure.Exceptions;
using ModularMonolith.Products.Application.Features.Attributes.Create.Dtos;
using ModularMonolith.Products.Application.Features.Products.Create;
using ModularMonolith.Products.Application.Features.Products.Create.Requests;
using ModularMonolith.Products.Application.Features.Products.Get;
using ModularMonolith.Products.Application.Features.Products.Get.Responses;
using ModularMonolith.Responses;

namespace ModularMonolith.Controllers.ProductCatalog;

[ApiController]
[Authorize]
[Route("product-catalog/[controller]")]
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
    public async Task<ActionResult> Products(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CreateProductCommand(
                request.Name,
                request.Description,
                request.Price,
                request.Attributes
                    .Select(x => new CreateAttributeDto(x.Id, x.SelectedValues)).ToList(),
                request.ManufacturerId),
            cancellationToken);

        return StatusCode(StatusCodes.Status201Created, new CreatedResponse(result));
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