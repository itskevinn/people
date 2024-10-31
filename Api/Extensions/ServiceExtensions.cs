using Application.Service;
using Application.Service.Implementation;

namespace Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddService(this IServiceCollection svc)
    {
        svc.AddTransient(typeof(IPersonService), typeof(PersonService));
        return svc;
    }
}