using System.Text.Json.Serialization;

namespace Domain;

public class Class
{
    public string Name { get; set; }
    public string TeacherId { get; set; }
    //public List<string> Students = new List<string>();
    public int Id { get; set; }

    [JsonConstructor]
    public Class(string name, string teacherId, int id)
    {
        Name = name;
        Id = id;
        TeacherId = teacherId;
        //Students = students;
    }
}