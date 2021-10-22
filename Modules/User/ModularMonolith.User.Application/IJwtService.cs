using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ModularMonolith.User.Application
{
    public interface IJwtService
    {
        string GenerateJwt(List<Claim> claims);
    }
}
