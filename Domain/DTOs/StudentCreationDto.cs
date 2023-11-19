using System.Text.Json.Serialization;

namespace Domain.DTOs;

public class StudentCreationDto : UserCreationDto
{
    
    [JsonPropertyName("UserId")]
    public int UserId { get; set; }
    [JsonPropertyName("Class")]
    public string AssignedClass { get; set; }

    public StudentCreationDto(string id, string password, int userId, string name, string assignedToClass) : base(id, password, name)
    {
        UserId = userId;
        Name = name;
        AssignedClass = assignedToClass;
    }
    
    public StudentCreationDto(){}
}