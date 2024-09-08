using System;

namespace ModularMonolith.Exceptions.Abstraction.Application;

public abstract class AppException : Exception
{
    public string ExceptionCode { get; }

    protected AppException(string message, string exceptionCode) : base(message)
    {
        ExceptionCode = exceptionCode;
    }
}