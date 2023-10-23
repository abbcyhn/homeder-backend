using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Commons.DataAccess;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria { get; }
    List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> Includes { get; }
    Expression<Func<T, object>> OrderBy { get; }
    Expression<Func<T, object>> OrderByDesc { get; }
    int Skip { get; }
    int Take { get; }
    bool IsPagingEnabled { get; }
}