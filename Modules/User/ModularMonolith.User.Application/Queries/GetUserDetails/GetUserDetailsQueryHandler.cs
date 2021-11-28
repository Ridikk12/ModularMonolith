using MediatR;
using Microsoft.AspNetCore.Identity;
using ModularMonolith.Exceptions.Abstraction;
using ModularMonolith.User.Application.Entities;
using ModularMonolith.User.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace ModularMonolith.User.Application.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDto>, IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        public GetUserDetailsQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<UserDto> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user is null)
                throw new NotFoundException(request.UserId, nameof(AppUser));

            return new UserDto(user.UserName, user.Name, user.Surname);
        }

        public Task<UserDto> GetUserDetails(string userId)
        {
            return Handle(new GetUserDetailsQuery(userId), CancellationToken.None);
        }
    }
}
