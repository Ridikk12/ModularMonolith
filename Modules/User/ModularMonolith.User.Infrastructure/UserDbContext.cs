using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModularMonolith.User.Infrastructure.Entities;

namespace ModularMonolith.User.Infrastructure
{
    public class UserDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.\;Database=ModularMonolith;Integrated Security=True");
        }
    }
}
