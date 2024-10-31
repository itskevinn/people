using Application.Http;
using Application.Http.Dto;
using Application.Http.Request;
using Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller;

[ApiController]
[Route("api/v1/[controller]")]
public class PersonController(IPersonService personService) : ControllerBase

{
    [HttpGet("all")]
    public async Task<Response<IEnumerable<PersonDto>>> GetAllAsync()
    {
        return await personService.GetAsync();
    }

    [HttpPost("save")]
    public async Task<Response<PersonDto>> CreateAsync([FromBody] PersonRequest request)
    {
        return await personService.CreateAsync(request);
    }

    [HttpDelete("delete")]
    public async Task<Response<PersonDto>> DeleteAsync(Guid id)
    {
        return await personService.DeleteAsync(id);
    }

    [HttpPut("update")]
    public async Task<Response<PersonDto>> UpdateAsync([FromBody] PersonDto request)
    {
        return await personService.UpdateAsync(request);
    }
}