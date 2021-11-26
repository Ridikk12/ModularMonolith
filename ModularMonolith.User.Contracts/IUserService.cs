using System;
using System.Threading.Tasks;

namespace ModularMonolith.User.Contracts
{
    public interface IUserService
    {
        Task<UserDto> GetUserDetails(string userId);
    }

    public class UserDto
    {
        public UserDto(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }
        public string Name { get; }
        public string Surname { get; }
        public string Email { get; }

        public string FullName => $"{Name} {Surname}";
    }
}
