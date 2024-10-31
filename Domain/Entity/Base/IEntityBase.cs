namespace Domain.Entity;

public interface IEntityBase<T>
{
    public T Id { get; set; }
    public bool Active { get; set; }
}