using System.Linq.Expressions;
using Domain.Entity;

namespace Domain.Ports.Base;

public interface IReadOnlyRepository<TEntity, in TKey> where TEntity : EntityBase<TKey>
{
    Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null);
    Task<TEntity?> FindByAsync(Expression<Func<TEntity, bool>>? filter = null);
    Task<TEntity?> FindAsync(TKey key);
}