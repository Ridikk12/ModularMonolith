using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModularMonolith.User.Application.Commands.Register;
using ModularMonolith.User.Application.Queries.GetUserDetails;
using ModularMonolith.User.Application.Queries.Login;
using ModularMonolith.User.Contracts;

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
        [Route("login")]
        public async Task<ActionResult<LoginResponse>> LogIn(LoginRequest request)
            => Ok(await _mediator.Send(new LoginQuery(request.UserName, request.Password)));


        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(RegisterRequest request) =>
            Ok(await _mediator.Send(new RegisterUserCommand(request.UserName, request.Password, request.Name, request.Password)));

        [HttpGet]
        [Route("{userId}")]
        public async Task<ActionResult<UserDto>> GetUserDetails(string userId, CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(new GetUserDetailsQuery(userId), cancellationToken));

    }
}
