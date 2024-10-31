namespace Domain.Entity;

public class AuditableEntity<T> : EntityBase<T>, IAuditableEntity<T>
{
    public string CreatedBy { get; set; } = default!;
    public DateTime CreatedOn { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime LastModifiedOn { get; set; }
}