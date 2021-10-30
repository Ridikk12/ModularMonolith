using System;
using System.Collections.Generic;
using System.Text;

namespace ModularMonolith.User.Application.Commands.Login
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
