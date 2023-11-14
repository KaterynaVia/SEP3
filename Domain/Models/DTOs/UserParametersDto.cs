namespace Domain.Models.DTOs;

public class UserParametersDto
{
    public int? IdContains { get;  }

    public UserParametersDto(int? idContains)
    {
        IdContains = idContains;
    }
}