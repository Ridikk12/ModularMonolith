namespace ModularMonolith.Infrastructure.Exceptions
{
    public class ErrorMessage
    {
        public ErrorMessage(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
        public int StatusCode { get; }
        public string Message { get; }
    }
}