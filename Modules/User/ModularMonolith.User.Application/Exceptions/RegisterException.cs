using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using ModularMonolith.Exceptions.Abstraction;

namespace ModularMonolith.User.Application.Exceptions
{
    public class RegisterException : ModularMonolithValidationException
    {
        public RegisterException(IEnumerable<IdentityError> errors) : base("Unable to register account.", 102)
        {
            ValidationMessages = errors.Select(x => x.Description).ToList();
        }
    }
}
