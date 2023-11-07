namespace Domain.DTOs;

public class SearchUserParametersDto
{
    public string? IdContains { get;  }

    public SearchUserParametersDto(string? idContains)
    {
        IdContains = idContains;
    }
}