using Core.Entities;
using System.Linq.Expressions;

namespace Core.Ioc.Services;

public interface IGenericService<TEntity, TEntityId>
    where TEntity : Entity<TEntityId>
    where TEntityId : struct
{
    Task<TEntity> GetByIdAsync(TEntityId id);
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity> AddAsync(TEntity newEntity);
    Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> newEntities);

    Task UpdateAsync(TEntity entity);

    Task RemoveAsync(TEntityId id);
    Task RemoveRangeAsync(IEnumerable<TEntityId> ids);

    Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> expression);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
}
