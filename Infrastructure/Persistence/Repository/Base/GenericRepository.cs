using Domain.Entity;
using Domain.Exceptions;
using Domain.Ports.Base;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository.Base;

public class GenericRepository<TEntity, TKey>(PeopleContext peopleContext)
    : ReadOnlyRepository<TEntity, TKey>(peopleContext), IGenericRepository<TEntity, TKey> where TEntity :
    EntityBase<TKey>
{
    private readonly PeopleContext _peopleContext = peopleContext;
    private readonly DbSet<TEntity> _dbSet = peopleContext.Set<TEntity>();

    public async Task Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
        await _peopleContext.SaveChangesAsync();
    }

    public async Task Delete(TKey key)
    {
        var entity = await _dbSet.FindAsync(key) ?? throw new NotFoundException("the key does not exist");
        _peopleContext.Remove(entity);

        await _peopleContext.SaveChangesAsync();
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        if (await _dbSet.FindAsync(entity.Id) != null)
            throw new AlreadyExistsException("the entity is already registered");
        await _dbSet.AddAsync(entity);
        await _peopleContext.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        if (await _dbSet.FindAsync(entity.Id) == null) throw new NotFoundException("the key does not exist");
        _peopleContext.ChangeTracker.Clear();
        _dbSet.Update(entity);
        await _peopleContext.SaveChangesAsync();
        return entity;
    }
}