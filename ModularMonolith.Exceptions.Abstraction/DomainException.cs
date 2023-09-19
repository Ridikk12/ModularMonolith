using System;

namespace ModularMonolith.Exceptions.Abstraction
{
    public abstract class DomainException : Exception
    {
        public int ExceptionCode { get; }
        public DomainException(string message, int exceptionCode) : base(message)
        {
            ExceptionCode = exceptionCode;
        }
    }
}

public static class ExceptionCodes
{
    public static int ProductAlreadySold = 1000;
}

