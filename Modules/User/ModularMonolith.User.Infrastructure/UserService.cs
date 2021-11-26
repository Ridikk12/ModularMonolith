using ModularMonolith.User.Contracts;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ModularMonolith.User.Infrastructure.Entities;

namespace ModularMonolith.User.Infrastructure
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<UserDto> GetUserDetails(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user is null ? null : new UserDto(user.Name, user.Surname, user.Email);
        }
    }
}
