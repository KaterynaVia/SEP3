namespace Domain.DTOs;

/// <summary>
///  DTO for search parameters for users
///  This DTO is used to pass search parameters to the DAO
///  This DTO is used to pass search parameters to the DAO
/// </summary>

public class UserParametersDto
{
    public UserParametersDto(string idContains)
    {
        IdContains = idContains;
    }

    public string IdContains { get; }
}