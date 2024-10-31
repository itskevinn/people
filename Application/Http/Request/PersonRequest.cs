namespace Application.Http.Request;

public class PersonRequest
{
    public string Name { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public int Age { get; set; }
}