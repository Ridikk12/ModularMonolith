using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using ModularMonolith.User.Application.Entities;
using ModularMonolith.User.Application.Exceptions;

namespace ModularMonolith.User.Application.Commands.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var identity = await _userManager.CreateAsync(new AppUser(request.UserName, request.Name, request.Surname),
                request.Password);
            if (!identity.Succeeded)
                throw new RegisterException(identity.Errors);

            return Unit.Value;
        }
    }
}