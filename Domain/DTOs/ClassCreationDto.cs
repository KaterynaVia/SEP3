namespace Domain.DTOs;

public class ClassCreationDto
{
    public string Name { get; }
    public int Id { get; }
    public string TeacherID { get; }
    public List<Student> Students { get; }
    
    public ClassCreationDto(string name, string teacherID, List<Student> students, int id)
    {
        Id = id;
        Name = name;
        TeacherID = teacherID;
        Students = students;
    }
}