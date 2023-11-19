namespace Domain.DTOs;

public class UserParametersDto
{
    public string IdContains { get;  }

    public UserParametersDto(string idContains)
    {
        IdContains = idContains;
    }
}