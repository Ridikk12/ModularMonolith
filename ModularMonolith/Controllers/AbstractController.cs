using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModularMonolith.Responses;

namespace ModularMonolith.Controllers;

public class ModularMonolithController : ControllerBase
{
    protected IActionResult CreatedResponse(Guid id) =>
        StatusCode(StatusCodes.Status201Created, new Response<CreatedResponse>(new CreatedResponse(id)));
}

public class Response<T> where T : class
{
    public Response(T data)
    {
        Data = data;
    }

    public T Data { get; set; }
}

public class PageResponse<T> : Response<T> where T : class
{
    public PageResponse(T data, int totalCount) : base(data)
    {
        TotalCount = totalCount;
    }

    public int TotalCount { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}