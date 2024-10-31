using Application.Http;
using Application.Http.Dto;
using Application.Http.Request;

namespace Application.Service;

public interface IPersonService
{
    Task<Response<PersonDto>> FindAsync(Guid id);
    Task<Response<IEnumerable<PersonDto>>> GetAsync();
    Task<Response<PersonDto>> CreateAsync(PersonRequest request);
    Task<Response<PersonDto>> UpdateAsync(PersonDto request);
    Task<Response<PersonDto>> DeleteAsync(Guid id);
}