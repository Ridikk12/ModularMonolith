using Refit;
using System.Threading.Tasks;

namespace ModularMonolith.User.Contracts
{
    public interface IUserApi
    {
        [Get("/user/{userId}")]
        public Task<UserDto> GetUserDetails(string userId);
    }
}
