using System.Text.Json.Serialization;

namespace Domain;

public class Teacher : User
{
    public int UserId { get; set; }

    public string Name { get; set; }
    
    [JsonConstructor]
    public Teacher(string id, string password, string name) : base(id, password)
    {
        Name = name;
    }
    
    public Teacher(){}

    
}