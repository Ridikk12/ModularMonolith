using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModularMonolith.User.Application.Commands.Login;

namespace ModularMonolith.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<string>> LogIn(LoginRequest request)
        {
            var result = await _mediator.Send(new LoginCommand(request.UserName, request.Password));
            return string.IsNullOrEmpty(result) ? (ActionResult<string>) BadRequest() : Ok(result);
        }
    }
}
