using Application.Http.Request;

namespace Application.Http.Dto;

public class PersonDto : PersonRequest
{
    public Guid Id { get; set; } = Guid.Empty;
}