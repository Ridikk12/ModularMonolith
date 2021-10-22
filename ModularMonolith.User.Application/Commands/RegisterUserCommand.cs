using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace ModularMonolith.User.Application
{
    public class RegisterUserCommand : IRequest
    {
        public RegisterUserCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        public string UserName { get; }
        public string Password { get; }

    }

}
