using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModularMonolith.Responses;

namespace ModularMonolith.Controllers;

public class ModularMonolithController : ControllerBase
{
    protected IActionResult CreatedResponse(Guid id) =>
        StatusCode(StatusCodes.Status201Created, new CreatedResponse(id));
}