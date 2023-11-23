using System.Text.Json.Serialization;

namespace Domain;

public class Student : User
{
    [JsonPropertyName("Name")]
    public string Name { get; set; }
    public int UserId { get; set; }
    [JsonPropertyName("Class")]
    public string AssignedClass { get; set; }
    public Student(string id, string password, string name, string assignedToClass) : base(id, password)
    {
        Name = name;
        AssignedClass = assignedToClass;
    }
    
    public Student(){}
}