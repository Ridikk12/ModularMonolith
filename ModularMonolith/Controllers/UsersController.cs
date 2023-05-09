using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModularMonolith.Infrastructure.Exceptions;
using ModularMonolith.User.Application.Commands.Register;
using ModularMonolith.User.Application.Commands.Register.Requests;
using ModularMonolith.User.Application.Queries.GetUserDetails;
using ModularMonolith.User.Application.Queries.Login;
using ModularMonolith.User.Application.Queries.Login.Requests;
using ModularMonolith.User.Application.Queries.Login.Responses;
using ModularMonolith.User.Contracts;

namespace ModularMonolith.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Login using username and password
        /// </summary>
        /// <param name="request">Login request parameter</param>
        /// <returns>JWT Token</returns>
        [HttpPost]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("login")]
        public async Task<ActionResult<LoginResponse>> LogIn(LoginRequest request)
            => Ok(await _mediator.Send(new LoginQuery(request.UserName, request.Password)));

        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="request">Login request parameter</param>
        /// <returns>JWT Token</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(RegisterRequest request) =>
            Ok(await _mediator.Send(new RegisterUserCommand(request.UserName, request.Password, request.Name,
                request.Password)));

        /// <summary>
        /// Return user's details by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(UserDto),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Route("{userId}")]
        public async Task<ActionResult<UserDto>> GetUserDetails(string userId, CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(new GetUserDetailsQuery(userId), cancellationToken));
    }
}