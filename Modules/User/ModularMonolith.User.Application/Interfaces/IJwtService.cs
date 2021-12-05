using System.Collections.Generic;
using System.Security.Claims;

namespace ModularMonolith.User.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwt(List<Claim> claims);
    }
}
