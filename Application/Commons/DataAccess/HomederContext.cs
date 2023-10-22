using System.Reflection;
using Application.Commons.Entities;
using Application.Commons.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Commons.DataAccess;

public class HomederContext : DbContext
{
    public HomederContext(DbContextOptions<HomederContext> options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (File.Exists("logs.txt"))
        {
            File.Delete("logs.txt");
        }
        
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddProvider(new FileLoggerProvider("logs.txt"));
        });
        
        optionsBuilder.UseLoggerFactory(loggerFactory);
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseUpperSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e is { Entity: BaseEntity, State: EntityState.Added or EntityState.Modified });
        
        foreach (var entityEntry in entries)
        {
            if (entityEntry is { Entity: BaseEntity creatableEntity, State: EntityState.Added })
            {
                creatableEntity.CreateDate = DateTime.UtcNow;
            }
            
            if (entityEntry is { Entity: BaseEntity editableEntity, State: EntityState.Modified })
            {
                editableEntity.EditDate = DateTime.UtcNow;
            }
        }
        
        return base.SaveChangesAsync(cancellationToken);
    }
}