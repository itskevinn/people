namespace Domain.Entity;

public interface IAuditableEntity<T> : IEntityBase<T>
{
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime LastModifiedOn { get; set; }
}