namespace Domain;

public class Class
{
    public string Name { get; set; }
    public string TeacherId { get; set; }
    public List<string> Students = new List<string>();
    public int Id { get; set; }

    public Class(string name, string teacherId, List<string> students, int id)
    {
        TeacherId = teacherId;
        Students = students;
        Name = name;
        Id = id;
    }
    
    public Class(string teacherId, List<string> students, string name)
    {
        TeacherId = teacherId;
        Students = students;
        Name = name;
    }
    
    public Class(List<string> students, string name)
    {
        Students = students;
        Name = name;
    }
    
    public Class(string name)
    {
        Name = name;
    }
}