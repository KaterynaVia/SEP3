using System.Text.Json.Serialization;

namespace Domain.DTOs;

/// <summary>
///  DTO for creating a user
///  This DTO is used to pass user creation parameters to the DAO
/// </summary>

public class UserCreationDto
{
    public UserCreationDto(string id, string password, string name)     // Set the ID, password and name of the user to create
    {
        Id = id;
        Password = password;
        Name = name;
    }

    [JsonConstructor]
    public UserCreationDto(string id)                        // Set the ID of the user to create
    {
        Id = id;
    }

    public UserCreationDto()
    {
    }

    public string Id { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
}