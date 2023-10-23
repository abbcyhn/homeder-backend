using System.Collections;
using Application.Commons.Entities;

namespace Application.Commons.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly HomederContext _ctx;

    private Hashtable _repositories;

    public UnitOfWork(HomederContext ctx)
    {
        _ctx = ctx;
    }

    public void Dispose()
    {
        _ctx.Dispose();
    }

    public IGenericRepository<T> Repository<T>() where T : BaseEntity
    {
        _repositories ??= new Hashtable();

        var type = typeof(T).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(GenericRepository<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _ctx);

            _repositories.Add(type, repositoryInstance);
        }

        return (IGenericRepository<T>)_repositories[type]!;
    }

    public async Task<int> Complete(CancellationToken cancellationToken)
    {
        return await _ctx.SaveChangesAsync(cancellationToken);
    }
}