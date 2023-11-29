using System.Text.Json.Serialization;

namespace Domain.DTOs;

public class ClassCreationDto
{
    [JsonConstructor]
    public ClassCreationDto(string name, string teacherID, List<string> students)
    {
        Name = name;
        TeacherID = teacherID;
        Students = students;
    }

    public string Name { get; }
    public int Id { get; }
    public string TeacherID { get; }
    public List<string> Students { get; }
}