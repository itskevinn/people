using Domain.Ports;
using Domain.Ports.Base;
using Infrastructure.Persistence.Repository;
using Infrastructure.Persistence.Repository.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection svc)
    {
        svc.AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
        svc.AddTransient(typeof(IReadOnlyRepository<,>), typeof(ReadOnlyRepository<,>));
        svc.AddTransient(typeof(IPersonRepository), typeof(PersonRepository));
        return svc;
    }
}