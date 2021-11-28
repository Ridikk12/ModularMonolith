using System;
using System.Threading.Tasks;

namespace ModularMonolith.User.Contracts
{
    public interface IUserService
    {
        Task<UserDto> GetUserDetails(string userId);
    }
}
