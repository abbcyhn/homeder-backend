using Application.Commons.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Commons.DataAccess;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly HomederContext _ctx;

    public GenericRepository(HomederContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<T> GetEntityWithSpec(ISpecification<T> spec, bool asNoTrackingEnabled = false)
    {
        return asNoTrackingEnabled
            ? await ApplySpecification(spec).AsNoTracking().FirstOrDefaultAsync()
            : await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _ctx.Set<T>().ToListAsync();
    }

    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec, bool asNoTrackingEnabled = false)
    {
        return asNoTrackingEnabled
            ? await ApplySpecification(spec).AsNoTracking().ToListAsync()
            : await ApplySpecification(spec).ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _ctx.Set<T>().FindAsync(id);
    }

    public async Task<int> CountAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).CountAsync();
    }

    public void Insert(T entity)
    {
        _ctx.Set<T>().Add(entity);
    }

    public void InsertRange(List<T> entity)
    {
        _ctx.Set<T>().AddRange(entity);
    }

    public void Delete(T entity)
    {
        _ctx.Set<T>().Remove(entity);
    }

    public void DeleteRange(List<T> entities)
    {
        _ctx.Set<T>().RemoveRange(entities);
    }

    public void Update(T entity)
    {
        _ctx.Set<T>().Update(entity);
    }

    public void UpdateRange(List<T> entity)
    {
        _ctx.Set<T>().UpdateRange(entity);
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return SpecificationEvaluator<T>.GetQuery(_ctx.Set<T>().AsQueryable(), spec);
    }
}