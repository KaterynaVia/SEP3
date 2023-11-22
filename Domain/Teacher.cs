using System.Text.Json.Serialization;

namespace Domain;

/*
 * Represents a teacher user in the system
 */

public class Teacher : User
{
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

    public Teacher()
    {
    }

    public string Name { get; set; }
    public int UserId { get; set; }
}