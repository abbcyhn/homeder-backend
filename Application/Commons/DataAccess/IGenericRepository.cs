using Application.Commons.Entities;

namespace Application.Commons.DataAccess;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> ListAllAsync();

    Task<T> GetEntityWithSpec(ISpecification<T> spec, bool asNoTrackingEnabled = false);
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec, bool asNoTrackingEnabled = false);
    Task<int> CountAsync(ISpecification<T> spec);

    void Insert(T entity);
    void InsertRange(List<T> entity);

    void Update(T entity);
    void UpdateRange(List<T> entity);

    void Delete(T entity);
    void DeleteRange(List<T> entities);
}