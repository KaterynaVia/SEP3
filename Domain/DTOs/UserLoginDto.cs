namespace Domain.DTOs;

/// <summary>
///  DTO for creating a user
///  This DTO is used to pass user creation parameters to the DAO
///  This DTO is used to pass user login parameters to the DAO
/// </summary>

public class UserLoginDto
{
    public string Id { get; init; }
    public string Password { get; init; }
}