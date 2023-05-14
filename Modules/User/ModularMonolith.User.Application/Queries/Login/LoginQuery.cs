using MediatR;
using ModularMonolith.User.Application.Queries.Login.Responses;

namespace ModularMonolith.User.Application.Queries.Login
{
    public class LoginQuery : IRequest<LoginResponse>
    {
        public LoginQuery(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        public string UserName { get; }
        public string Password { get; }
    }
}
