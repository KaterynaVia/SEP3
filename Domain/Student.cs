using System.Text.Json.Serialization;

namespace Domain;

public class Student : User
{
    [JsonPropertyName("UserId")]
    public int UserId { get; set; }
    [JsonPropertyName("Name")]
    public string Name { get; set; }
    [JsonPropertyName("Class")]
    public string AssignedClass { get; set; }
    public Student(string id, string password, string name, int userId, string assignedToClass) : base(id, password)
    {
        Name = name;
        UserId = userId;
        AssignedClass = assignedToClass;
    }
    
    public Student(){}
}