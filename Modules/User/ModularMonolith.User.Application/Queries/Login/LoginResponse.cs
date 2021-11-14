using System;
using System.Collections.Generic;
using System.Text;

namespace ModularMonolith.User.Application.Queries.Login
{
    public class LoginResponse
    {
        public LoginResponse(string token)
        {
            Token = token;
        }
        public string Token { get; }
    }
}
