namespace Domain.DTOs;

/// <summary>
///  DTO for creating a teacher
///  This DTO is used to pass teacher creation parameters to the DAO
///  This DTO is used to pass teacher creation parameters to the DAO
/// </summary>

public class TeacherCreationDto : UserCreationDto
{
    public TeacherCreationDto(string id, string password, string name, int userId) : base(id, password, name)
    {
        UserId = userId;
    }

    public int UserId { get; }
}