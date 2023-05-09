namespace ModularMonolith.User.Application.Commands.Register.Requests
{
    public class RegisterRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
