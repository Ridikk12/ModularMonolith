using System;

namespace ModularMonolith.Exceptions.Abstraction.Application;

public class NotFoundException<T> : AppException where T : class
{
    public NotFoundException(Guid entityId) : base(
        $"Entity {nameof(T)}: {entityId} was not found.", $"entity.notfound.{nameof(T)}")
    {
    }
}