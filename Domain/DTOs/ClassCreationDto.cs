namespace Domain.DTOs;

public class ClassCreationDto
{
    public string Name { get; }
    public Teacher Teacher { get; }
    public List<Student> Students { get; }

    public ClassCreationDto(string name, Teacher teacher, List<Student> students)
    {
        Name = name;
        Teacher = teacher;
        Students = students;
    }
}