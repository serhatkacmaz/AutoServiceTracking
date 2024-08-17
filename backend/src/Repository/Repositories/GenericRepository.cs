using Core.Entities.Base;
using Core.Ioc.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using System.Linq.Expressions;

namespace Repositories;

public class GenericRepository<TEntity, TEntityId> : IGenericRepository<TEntity, TEntityId>
    where TEntity : Entity<TEntityId>
    where TEntityId : struct
{
    protected readonly AutoServiceTrackingContext context;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(AutoServiceTrackingContext context)
    {
        this.context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity> GetByIdAsync(TEntityId id)
    {
        return await _dbSet.FindAsync(id);
    }

    public IQueryable<TEntity> GetAll()
    {
        return _dbSet.AsNoTracking().AsQueryable();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void Remove(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
    {
        return _dbSet.Where(expression);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _dbSet.AnyAsync(expression);
    }
}