using Application.Http.Profiles;
using AutoMapper;

namespace Api.Extensions;

public static class AutoMapperExtensions
{
    public static IServiceCollection AddMapping(this IServiceCollection svc)
    {
        var mapperConfiguration = new MapperConfiguration(m => { m.AddProfile(new PersonProfile()); });
        svc.AddSingleton(mapperConfiguration.CreateMapper());
        return svc;
    }
}