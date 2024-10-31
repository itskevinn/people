using Domain.Entity;

namespace Domain.Ports.Base;

public interface IGenericRepository<TEntity, in TKey> : IReadOnlyRepository<TEntity, TKey> where TEntity :
    EntityBase<TKey>
{
    Task Delete(TEntity entity);
    Task Delete(TKey key);
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
}