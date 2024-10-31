namespace Domain.Entity;

public class EntityBase<T> : IEntityBase<T>
{
    public T Id { get; set; }
    public bool Active { get; set; }
}