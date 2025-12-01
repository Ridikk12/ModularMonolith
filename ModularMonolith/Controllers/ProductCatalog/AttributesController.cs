using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModularMonolith.Products.Application.Features.Attributes.Create;
using ModularMonolith.Products.Application.Features.Attributes.Create.Requests;
using ModularMonolith.Products.Application.Features.Attributes.Get;

namespace ModularMonolith.Controllers.ProductCatalog;

[ApiController]
[Authorize]
[Route("product-catalog/[controller]")]
public class AttributesController : ModularMonolithController
{
    private readonly IMediator _mediator;

    public AttributesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Attributes(CreateAttributeRequest request)
        => CreatedResponse(await _mediator.Send(new CreateAttributeCommand(request.Name, request.Values)));
    
    [HttpGet]
    public async Task<IActionResult> Attributes(GetAttributeRequest request)
        => Ok(await _mediator.Send(new GetAttributeQuery(request.Id)));
}