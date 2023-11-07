using System.Text.Json.Serialization;

namespace Domain;

public class Teacher : User
{
    public string Name { get; set; }
    
    [JsonConstructor]
    public Teacher(string name, string password, string id, int userId) : base(password, id)
    {
        Name = name;
    }
    
    public Teacher(string name, string password, string id) : base(password, id)
    {
        Name = name;
    }

    
}