using System.Linq.Expressions;
using Domain.Entity;
using Domain.Ports.Base;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository.Base;

public class ReadOnlyRepository<TEntity, TKey>(PeopleContext peopleContext) : IReadOnlyRepository<TEntity, TKey>
    where TEntity : EntityBase<TKey>
{
    private readonly DbSet<TEntity> _dbSet = peopleContext.Set<TEntity>();


    public async Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        IQueryable<TEntity> queryable = _dbSet;
        if (filter != null)
        {
            queryable = queryable.Where(filter);
        }

        return await Task.FromResult(queryable);
    }

    public async Task<TEntity?> FindByAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        IQueryable<TEntity> queryable = _dbSet;
        if (filter != null)
        {
            queryable = queryable.Where(filter);
        }

        return await Task.FromResult(queryable.First());
    }

    public async Task<TEntity?> FindAsync(TKey key)
    {
        return await _dbSet.FindAsync(key);
    }
}