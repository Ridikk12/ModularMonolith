using System;
using Microsoft.EntityFrameworkCore;
using ModularMonolith.Outbox.Persistence;

namespace ModularMonolith.Providers
{
    public interface IDbContextProvider
    {
        DbContext GetDbContext(string controllerName, IServiceProvider provider);
    }
}