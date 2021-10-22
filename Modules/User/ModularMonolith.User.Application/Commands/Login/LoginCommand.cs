using MediatR;

namespace ModularMonolith.User.Application.Commands.Login
{
    public class LoginCommand : IRequest<string>
    {
        public LoginCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        public string UserName { get; }
        public string  Password { get; }
    }
}
