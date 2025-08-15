using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using WarehouseSystem.Domain.Abstraction;
using WarehouseSystem.Infrastructure.Context;

namespace WarehouseSystem.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly WareHouseDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(WareHouseDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<int> CountAsync(
            Expression<Func<TEntity, bool>> predicate = null!, 
            CancellationToken cancellationToken = default)
        {
            var query = _dbSet.AsQueryable().AsNoTracking();
            if (predicate != null)
                query = query.Where(predicate);
            return await query.CountAsync(cancellationToken);
        }

        public ValueTask<EntityEntry<TEntity>> CreateAsync(
            TEntity entity, 
            CancellationToken cancellationToken = default)
        {
            return _dbSet.AddAsync(entity, cancellationToken);
        }

        public async Task<IReadOnlyCollection<TSelctor>> GetAllAsync<TSelctor>(
            Expression<Func<TEntity, TSelctor>> selector, 
            Expression<Func<TEntity, bool>> predicate = null!, 
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null!,
            CancellationToken cancellationToken = default)
        {
            var query = _dbSet.AsQueryable().AsNoTracking();
            if (predicate != null)
                query = query.Where(predicate);
            if(includes != null)
                query = includes(query);
            return await query.Select(selector)
                .ToListAsync(cancellationToken);
        }
        
        public Task<TSelector> GetAsync<TSelector>(
            Expression<Func<TEntity, bool>> predicate, 
            Expression<Func<TEntity, TSelector>> selector, 
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object?>> includes,
            bool asTracking = false, 
            CancellationToken cancellationToken = default)
        {
            var query = _dbSet.AsQueryable();
            if(!asTracking)
                query = query.AsNoTracking();

            if(predicate != null)
                query = query.Where(predicate);

            if(includes != null)
                query = includes(query);
            
            return query.Select(selector).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> IsAnyExistAsync(
            Expression<Func<TEntity, bool>> predicate, 
            CancellationToken cancellationToken = default)
        {
            return await _dbSet.AnyAsync(predicate, cancellationToken);
        }

        public async Task<(IReadOnlyCollection<TSelctor> Items, int TotalCount)> PaginateAsync<TSelctor>(
            int pageNumber, int pageSize, 
            Expression<Func<TEntity, TSelctor>> selector, 
            Expression<Func<TEntity, bool>> predicate = null!, 
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object?>> includes = null!, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> ordered = null!, 
            CancellationToken cancellationToken = default)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;

            var query = _dbSet.AsNoTracking().AsQueryable();

            if (predicate != null)
                query = query.Where(predicate);

            if (includes != null)
                query = includes(query);

            if (ordered != null)
                query = ordered(query);

            var totalCount = await query.CountAsync(cancellationToken);

            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            var items = await query.Select(selector).ToListAsync(cancellationToken);

            return (items, totalCount);
        }

        public ValueTask<EntityEntry<TEntity>> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return ValueTask.FromResult(_dbSet.Update(entity));
        }
    }
}
