using System;

namespace ModularMonolith.Exceptions.Abstraction
{
    public abstract class AppException : Exception
    {
        public int ExceptionCode { get; }

        protected AppException(string message, int exceptionCode) : base(message)
        {
            ExceptionCode = exceptionCode;
        }
    }

    public class NotFoundException : AppException
    {
        public NotFoundException(string entityId, string entityType) : base($"Entity {entityType} {entityId} was not found.", 9000)
        {

        }
    }
}
