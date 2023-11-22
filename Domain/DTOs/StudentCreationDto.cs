using System.Text.Json.Serialization;

namespace Domain.DTOs;

/// <summary>
///  DTO for creating a user
///  This DTO is used to pass user creation parameters to the DAO
///  This DTO is used to pass user login parameters to the DAO
/// </summary>

public class StudentCreationDto : UserCreationDto
{
    public StudentCreationDto(string id, string password, int userId, string name, string assignedToClass) : base(id,
        password, name)
    {
        UserId = userId;
        Name = name;
        AssignedClass = assignedToClass;
    }

    public StudentCreationDto()
    {
    }

    [JsonPropertyName("UserId")] public int UserId { get; set; }

    [JsonPropertyName("Class")] public string AssignedClass { get; set; }
}