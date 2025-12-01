using System;

namespace ModularMonolith.Exceptions.Abstraction.Domain;
public abstract class DomainException : Exception
{
    public string ExceptionCode { get; }

    protected DomainException(string message, string exceptionCode) : base(message)
    {
        ExceptionCode = exceptionCode;
    }
}