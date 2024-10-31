using Application.Http.Dto;
using Application.Http.Request;
using AutoMapper;
using Domain.Entity;

namespace Application.Http.Profiles;

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<Person, PersonDto>();
        CreateMap<PersonRequest, Person>();
    }
}