using System.Collections.Generic;

namespace ModularMonolith.Exceptions.Abstraction.Application;

public abstract class ModularMonolithValidationException : AppException
{
    public List<string> ValidationMessages { get; set; }
    protected ModularMonolithValidationException(string message, string exceptionCode) : base(message, exceptionCode)
    {
    }
}