using Application.Commons.Entities;
using Application.Commons.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Commons;

public class AppDbContext : DbContext
{
    private readonly Dictionary<string, object> keyValuePairs;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        keyValuePairs = new Dictionary<string, object>();
    }

    public DbSet<TEntity> GetEntity<TEntity>() where TEntity : class {
        string key = typeof(TEntity).Name;
        if (keyValuePairs.ContainsKey(key)) 
        {
            keyValuePairs.TryGetValue(key, out var valObj);
            return valObj as DbSet<TEntity>;
        }
        DbSet<TEntity> val = Set<TEntity>();
        keyValuePairs.Add(key, val);
        return val;
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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public override int SaveChanges()
    {
        SetDefaultValues();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        SetDefaultValues();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void SetDefaultValues()
    {
        var entries = ChangeTracker.Entries();

        foreach (var entityEntry in entries)
        {
            if (entityEntry.Entity is ICreatableEntity && entityEntry.State == EntityState.Added)
            {
                ((ICreatableEntity)entityEntry.Entity).CreateDate = DateTime.UtcNow;
            }
            if (entityEntry.Entity is IEditableEntity && entityEntry.State == EntityState.Modified)
            {
                ((IEditableEntity)entityEntry.Entity).EditDate = DateTime.UtcNow;
            }
        }
    }
}
