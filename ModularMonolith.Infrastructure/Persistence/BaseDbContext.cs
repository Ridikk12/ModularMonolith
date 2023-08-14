using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ModularMonolith.Domain.Entities;
using ModularMonolith.Infrastructure.Services;

namespace ModularMonolith.Infrastructure.Persistence;

public class BaseDbContext : DbContext
{
    private readonly IUserContext _userContext;
    
    protected BaseDbContext(DbContextOptions options, IUserContext userContext)
        : base(options)
    {
        _userContext = userContext;
    }
    
    protected BaseDbContext(DbContextOptions options)
        : base(options)
    {
        
    }

    protected void SetAuditFields()
    {
        var changedEntities = ChangeTracker.Entries<BaseEntity>()
            .Where(ce => ce.State is EntityState.Added or EntityState.Modified);

        var userId = _userContext.UserId;

        foreach (var auditableEntity in changedEntities)
        {
            var currentDate = DateTime.UtcNow;

            switch (auditableEntity.State)
            {
                case EntityState.Added:
                    auditableEntity.Entity.CreatedDate = currentDate;
                    auditableEntity.Entity.ModifiedDate = currentDate;
                    auditableEntity.Entity.CreatedBy = userId;
                    auditableEntity.Entity.ModifiedBy = userId;
                    break;
                case EntityState.Modified:
                    auditableEntity.Entity.ModifiedDate = currentDate;
                    auditableEntity.Entity.ModifiedBy = userId;
                    break;
            }
        }
    }
}

