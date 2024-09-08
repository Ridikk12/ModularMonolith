using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using ModularMonolith.Exceptions.Abstraction;
using ModularMonolith.Exceptions.Abstraction.Application;

namespace ModularMonolith.User.Application.Exceptions
{
    public class RegisterException : ModularMonolithValidationException
    {
        public RegisterException(IEnumerable<IdentityError> errors) : base("Unable to register account.",
            ExceptionCodes.RegisterFailed)
        {
            ValidationMessages = errors.Select(x => x.Description).ToList();
        }
    }
}