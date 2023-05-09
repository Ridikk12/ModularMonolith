using MediatR;

namespace ModularMonolith.User.Application.Commands.Register
{
    public class RegisterUserCommand : IRequest
    {
        public RegisterUserCommand(string userName, string password, string name, string surname)
        {
            UserName = userName;
            Password = password;
            Name = name;
            Surname = surname;
        }

        public string UserName { get; }
        public string Password { get; }
        public string Name { get; }
        public string Surname { get; }
    }
}