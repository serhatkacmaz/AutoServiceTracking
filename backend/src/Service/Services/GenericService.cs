using Core.Entities.Base;
using Core.Ioc.Repositories;
using Core.Ioc.Services;
using Core.Ioc.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Service.Exceptions;
using System.Linq.Expressions;

namespace Service.Services;

public class GenericService<TEntity, TEntityId> : IGenericService<TEntity, TEntityId>
    where TEntity : Entity<TEntityId>
    where TEntityId : struct
{
    private readonly IGenericRepository<TEntity, TEntityId> _repository;
    protected readonly IUnitOfWork _unitOfWork;

    public GenericService(IGenericRepository<TEntity, TEntityId> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<TEntity> GetByIdAsync(TEntityId id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundException($"{typeof(TEntity).Name}({id}) not found");

        return entity;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var entities = await _repository.GetAll().ToListAsync();
        return entities;
    }

    public async Task<TEntity> AddAsync(TEntity newEntity)
    {
        await _repository.AddAsync(newEntity);
        await _unitOfWork.CommitAsync();

        return newEntity;
    }

    public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> newEntities)
    {
        await _repository.AddRangeAsync(newEntities);
        await _unitOfWork.CommitAsync();

        return newEntities;
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _repository.Update(entity);
        await _unitOfWork.CommitAsync();
    }

    public async Task RemoveAsync(TEntityId id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundException($"{typeof(TEntity).Name}({id}) not found");

        _repository.Remove(entity);
        await _unitOfWork.CommitAsync();
    }

    public async Task RemoveRangeAsync(IEnumerable<TEntityId> ids)
    {
        var entities = await _repository.Where(x => ids.Contains(x.Id)).ToListAsync();
        _repository.RemoveRange(entities);

        await _unitOfWork.CommitAsync();
    }

    public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> expression)
    {
        var entities = await _repository.Where(expression).ToListAsync();
        return entities;
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
    {
        var anyEntity = await _repository.AnyAsync(expression);
        return anyEntity;
    }
}