using Domain.Entity;
using Domain.Ports;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repository.Base;

namespace Infrastructure.Persistence.Repository;

public class PersonRepository(PeopleContext peopleContext)
    : GenericRepository<Person, Guid>(peopleContext), IPersonRepository
{
}