using ModularMonolith.Exceptions.Abstraction.Application;

namespace ModularMonolith.User.Application.Exceptions;

public class UserNotFoundException : AppException
{
    public UserNotFoundException(string userId) : base($"User not found: ${userId}", ExceptionCodes.UserNotFound)
    {
    }
}