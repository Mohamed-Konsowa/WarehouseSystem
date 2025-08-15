using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace WarehouseSystem.Domain.Abstraction
{
    public interface IRepository<TEntity>  where TEntity : class
    {
        Task<int> CountAsync(
            Expression<Func<TEntity, bool>> predicate = null!,
            CancellationToken cancellationToken = default
        );

        ValueTask<EntityEntry<TEntity>> CreateAsync(
            TEntity entity,
            CancellationToken cancellationToken = default
        );

        Task<IReadOnlyCollection<TSelctor>> GetAllAsync<TSelctor>(
            Expression<Func<TEntity, TSelctor>> Selector,
            Expression<Func<TEntity, bool>> predicate = default!,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null!,
            CancellationToken cancellationToken = default
        );

        Task<TSelector> GetAsync<TSelector>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TSelector>> selector,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object?>> includes,
            bool asTracking = false,
            CancellationToken cancellationToken = default
        );

        Task<bool> IsAnyExistAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default
        );

        Task<(IReadOnlyCollection<TSelctor> Items, int TotalCount)> PaginateAsync<TSelctor>(
            int pageNumber,
            int pageSize,
            Expression<Func<TEntity, TSelctor>> selector,
            Expression<Func<TEntity, bool>> predicate = null!,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object?>> includes = null!,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> ordered = null!,
            CancellationToken cancellationToken = default
        );

        ValueTask<EntityEntry<TEntity>> UpdateAsync(
            TEntity entity,
            CancellationToken cancellationToken = default
        );
    }
}
