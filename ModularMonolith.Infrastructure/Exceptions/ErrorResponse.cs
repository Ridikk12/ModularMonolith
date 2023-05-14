using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace ModularMonolith.Infrastructure.Exceptions
{
    public class ErrorResponse
    {
        public ErrorResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public ErrorResponse(IEnumerable<ValidationFailure> failures, string errorMessage, int statusCode)
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
            Message = errorMessage;
            StatusCode = statusCode;
        }

        public ErrorResponse(int statusCode, string message, List<string> validationMessages)
        {
            StatusCode = statusCode;
            Message = message;

            Errors = validationMessages
                .Select((s, index) => new { s, index })
                .ToDictionary(x => (x.index + 1).ToString(), x => new string[] { x.s });
        }

        public int StatusCode { get; }
        public string Message { get; }

        public IDictionary<string, string[]> Errors { get; }
    }
}