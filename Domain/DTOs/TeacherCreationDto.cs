namespace Domain.DTOs;

public class TeacherCreationDto : UserCreationDto
{
    public int UserId { get; }

    public TeacherCreationDto(string id, string password, string name, int userId) : base(id, password, name)
    {
        UserId = userId;
    }
}