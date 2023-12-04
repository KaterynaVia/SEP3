using System.Text.Json.Serialization;

namespace Domain;

public class Class
{
    [JsonConstructor]
    public Class(string name, string teacherId, int id, List<string?> students)
    {
        Name = name;
        Id = id;
        TeacherId = teacherId;
        Students = students;
    }

    public string Name { get; set; }

    public string TeacherId { get; set; }

    public List<string?> Students  { get; set; } = new List<string?>();
    public int Id { get; set; }
}