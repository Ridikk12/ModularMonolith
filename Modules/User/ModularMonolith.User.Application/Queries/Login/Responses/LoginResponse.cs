namespace ModularMonolith.User.Application.Queries.Login.Responses
{
    public class LoginResponse
    {
        public LoginResponse(string token)
        {
            Token = token;
        }
        public string Token { get; }
    }
}
