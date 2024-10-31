using Domain.Entity;
using Domain.Ports.Base;

namespace Domain.Ports;

public interface IPersonRepository : IGenericRepository<Person, Guid>
{
}