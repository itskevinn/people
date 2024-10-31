using System.Net;
using Application.Http;
using Application.Http.Dto;
using Application.Http.Request;
using AutoMapper;
using Domain.Entity;
using Domain.Exceptions;
using Domain.Ports;

namespace Application.Service.Implementation;

public class PersonService(IPersonRepository personRepository, IMapper mapper) : IPersonService
{
    private const string ErrorMessage = "Ocurrió un error";

    public async Task<Response<PersonDto>> FindAsync(Guid id)
    {
        try
        {
            var person = await personRepository.FindAsync(id);
            if (person == null) throw new NotFoundException("person not found");
            var personDto = mapper.Map<PersonDto>(person);
            return new Response<PersonDto>("Persona: ", HttpStatusCode.OK, personDto);
        }
        catch (NotFoundException)
        {
            return new Response<PersonDto>("Persona no encontrada ", HttpStatusCode.BadRequest);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new Response<PersonDto>(ErrorMessage, HttpStatusCode.InternalServerError);
        }
    }

    public async Task<Response<IEnumerable<PersonDto>>> GetAsync()
    {
        try
        {
            IEnumerable<Person> people = await personRepository.GetAsync();
            var peopleDtoList = mapper.Map<IEnumerable<PersonDto>>(people.AsEnumerable());
            return new Response<IEnumerable<PersonDto>>("Personas: ", HttpStatusCode.OK, peopleDtoList);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new Response<IEnumerable<PersonDto>>(ErrorMessage, HttpStatusCode.InternalServerError);
        }
    }

    public async Task<Response<PersonDto>> CreateAsync(PersonRequest request)
    {
        try
        {
            var person = mapper.Map<Person>(request);
            person.CreatedBy = "admin";
            person.CreatedOn = DateTime.Now;
            person = await personRepository.CreateAsync(person);
            var personDto = mapper.Map<PersonDto>(person);
            return new Response<PersonDto>("Persona creada: ", HttpStatusCode.OK, personDto);
        }
        catch (AlreadyExistsException)
        {
            return new Response<PersonDto>("Persona ya existe ", HttpStatusCode.BadRequest);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new Response<PersonDto>(ErrorMessage, HttpStatusCode.InternalServerError);
        }
    }

    public async Task<Response<PersonDto>> UpdateAsync(PersonDto request)
    {
        try
        {
            var foundPerson = await personRepository.FindAsync(request.Id);
            if (foundPerson == null)
                throw new NotFoundException("Persona con " + request.Id + "  no fue encontrada");
            var person = mapper.Map<Person>(request);
            person.LastModifiedBy = "admin";
            person.LastModifiedOn = DateTime.Now;
            person.CreatedOn = foundPerson.CreatedOn;
            person.CreatedBy = foundPerson.CreatedBy;
            person = await personRepository.UpdateAsync(person);
            var personDto = mapper.Map<PersonDto>(person);
            return new Response<PersonDto>("Persona actualizada: ", HttpStatusCode.OK, personDto);
        }
        catch (NotFoundException)
        {
            return new Response<PersonDto>("Persona no existe ", HttpStatusCode.BadRequest);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new Response<PersonDto>(ErrorMessage, HttpStatusCode.InternalServerError);
        }
    }

    public async Task<Response<PersonDto>> DeleteAsync(Guid id)
    {
        try
        {
            await personRepository.Delete(id);
            return new Response<PersonDto>("Persona eliminada.", HttpStatusCode.OK);
        }
        catch (NotFoundException)
        {
            return new Response<PersonDto>("Persona no existe ", HttpStatusCode.BadRequest);
        }
    }
}