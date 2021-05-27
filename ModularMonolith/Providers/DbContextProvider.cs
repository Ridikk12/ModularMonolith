using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Controllers;
using ModularMonolith.History.Infrastructure;
using ModularMonolith.Outbox.Persistence;
using ModularMonolith.Product.Infrastructure;

namespace ModularMonolith.Providers
{
    public class DbContextProvider : IDbContextProvider
    {
        public DbContext GetDbContext(string controllerName, IServiceProvider provider)
        {
            controllerName += "Controller";

            return controllerName switch {
                nameof(ProductController) => provider.GetService<ProductDbContext>(),
                nameof(HistoryController) => provider.GetService<HistoryDbContext>(),
                _ => throw new ArgumentException("No DbContext present for requested route.", nameof(controllerName))
            };
        }
    }
}
