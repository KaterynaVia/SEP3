using System.Text.Json.Serialization;

namespace Domain;

/*
 * Represents a student user in the system
*/

public class Student : User
{
    public Student(string id, string password, string name, int userId, string assignedToClass) : base(id, password)
    {
        Name = name;
        UserId = userId;
        AssignedClass = assignedToClass;
    }

    public Student()
    {
    }

    [JsonPropertyName("UserId")] public int UserId { get; set; }        // The student's ID

    [JsonPropertyName("Name")] public string Name { get; set; }         // The student's name

    [JsonPropertyName("Class")] public string AssignedClass { get; set; }       // The class the student is assigned to
}