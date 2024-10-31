using System.Linq.Expressions;
using Domain.Entity;
using Domain.Ports.Base;

namespace Infrastructure.Persistence.Base;

public class ReadOnlyRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey> where TEntity : EntityBase<TKey>
{
    public Task<IQueryable<TEntity>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> FindByAsync(Expression<Func<TEntity, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> FindAsync(TKey key)
    {
        throw new NotImplementedException();
    }
}