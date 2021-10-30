using System;
using System.Collections.Generic;

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

    public abstract class ValidationException : AppException
    {
        public List<string> ValidationMessages { get; set; }
        protected ValidationException(string message, int exceptionCode) : base(message, exceptionCode)
        {
        }
    }

    public class NotFoundException : AppException
    {
        public NotFoundException(string entityId, string entityType) : base($"Entity {entityType} {entityId} was not found.", 9000)
        {

        }
    }
}
