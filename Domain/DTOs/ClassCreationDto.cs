using System.Text.Json.Serialization;

namespace Domain.DTOs;

public class ClassCreationDto
{
    [JsonConstructor]
    public ClassCreationDto(string name, string teacherID)
    {
        Name = name;
        TeacherID = teacherID;
        //Students = students;
    }
    
    public ClassCreationDto(string name, string teacherID, string student)
    {
        Name = name;
        TeacherID = teacherID;
        Student = student;
    }

    public string Name { get; }
    public int Id { get; }
    public string TeacherID { get; }
    //public List<string> Students { get; }
    public string Student { get; }
}