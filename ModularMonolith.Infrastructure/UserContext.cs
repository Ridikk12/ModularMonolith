using Microsoft.AspNetCore.Http;
using System.Linq;

namespace ModularMonolith.Infrastructure
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public UserContext(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string UserId
        {
            get
            {
                return _contextAccessor?.HttpContext.User.Claims.First(x => x.Type == "UserId").Value;
            }
        }
    }
}
