namespace Domain.DTOs;

/// <summary>
///  DTO for creating a class
///  This DTO is used to pass class creation parameters to the DAO
///  This DTO is used to pass class creation parameters to the DAO
/// </summary>

public class ClassCreationDto
{
    public ClassCreationDto(string name, Teacher teacher, List<Student> students)
    {
        Name = name;
        Teacher = teacher;
        Students = students;
    }

    public string Name { get; }
    public Teacher Teacher { get; }
    public List<Student> Students { get; }
}