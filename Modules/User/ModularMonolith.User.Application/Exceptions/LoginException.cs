using ModularMonolith.Exceptions.Abstraction;
using ModularMonolith.Exceptions.Abstraction.Application;

namespace ModularMonolith.User.Application.Exceptions
{
    public class LoginException : AppException
    {
        public LoginException() : base("Unable to login. Wrong Username or Password",
            ExceptionCodes.UserPasswordInvalid)
        {
        }
    }
}