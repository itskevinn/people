using Domain.Entity.Base;

namespace Domain.Entity;

public class Person : AuditableEntity<Guid>
{
    public string Name { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public int Age { get; set; }
}