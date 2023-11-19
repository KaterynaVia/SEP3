using System.Text.Json.Serialization;

namespace Domain;

public class Teacher : User
{
    public string Name { get; set; }
    public int UserId { get; set; }
    
    [JsonConstructor]
    public Teacher(string name, string password, string id, int userId) : base(id, password)
    {
        Name = name;
        UserId = userId;
    }
    
    public Teacher(string name, string password, string id) : base(password, id)
    {
        Name = name;
    }
    
    public Teacher(){}

    
}