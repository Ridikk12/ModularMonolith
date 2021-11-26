using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace ModularMonolith.User.Contracts
{
    public interface IUserApi
    {
        [Get("/user/{userId}")]
        public Task<UserDto> GetUserDetails(string userId);
    }
}
