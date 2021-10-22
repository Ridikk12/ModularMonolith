using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ModularMonolith.User.Infrastructure
{
    public class UserDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {

    }
}
