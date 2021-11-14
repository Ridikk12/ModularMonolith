using ModularMonolith.Exceptions.Abstraction;

namespace ModularMonolith.User.Application.Exceptions
{
    public class LoginException : AppException
    {
        public LoginException() : base("Unable to login. Wrong Username or Password", 102)
        {
        }
    }
}
