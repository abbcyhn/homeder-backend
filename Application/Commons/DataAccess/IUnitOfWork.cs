using Application.Commons.Entities;

namespace Application.Commons.DataAccess;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<T> Repository<T>() where T : BaseEntity;
    Task<int> Complete(CancellationToken cancellationToken);
}