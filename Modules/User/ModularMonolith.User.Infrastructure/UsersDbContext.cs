using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModularMonolith.User.Application.Entities;

namespace ModularMonolith.User.Infrastructure
{
    public class UsersDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }
    }
}
