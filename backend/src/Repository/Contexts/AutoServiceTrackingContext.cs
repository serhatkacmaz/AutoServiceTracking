using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Security.Claims;

namespace Repository.Contexts;

public class AutoServiceTrackingContext : DbContext
{
    protected IHttpContextAccessor HttpContextAccessor;

    public AutoServiceTrackingContext(DbContextOptions<AutoServiceTrackingContext> dbContextOptions, IHttpContextAccessor httpContextAccessor) : base(dbContextOptions)
    {
        HttpContextAccessor = httpContextAccessor;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    #region SaveChanges
    public override int SaveChanges()
    {
        PreSaveChanges();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        PreSaveChanges();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        PreSaveChanges();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        PreSaveChanges();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void PreSaveChanges()
    {
        string? userId = HttpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var modifiedEntries = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
            .ToList();

        foreach (var entry in modifiedEntries)
        {
            if (entry.Entity is IAudit entity)
            {
                if (entry.State == EntityState.Added)
                {
                    entity.CreatedBy = userId != null ? int.Parse(userId) : null;
                    entity.CreatedDate = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entity.UpdatedBy = userId != null ? int.Parse(userId) : null;
                    entity.UpdatedDate = DateTime.UtcNow;
                }
            }
        }
    }
    #endregion

    public DbSet<User> Users { get; set; }
    public DbSet<ServiceEntry> ServiceEntries { get; set; }
}
