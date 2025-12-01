using System.Linq;
using Microsoft.AspNetCore.Http;

namespace ModularMonolith.Infrastructure.Services
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private const string UserClaimType = "UserId";
        public UserContext(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string UserId
        {
            get
            {
                return _contextAccessor?.HttpContext?.User.Claims.First(x => x.Type == UserClaimType).Value;
            }
        }
    }
}
