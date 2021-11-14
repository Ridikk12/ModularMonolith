
using System.Text.Json.Serialization;

namespace ModularMonolith.User.Application.Commands.Register
{
    public class RegisterRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
