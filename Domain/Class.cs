namespace Domain;

public class Class
{
    public string Name { get; set; }
    public Teacher Teacher { get; set; }
    public List<Student> Students = new List<Student>();
    public int Id { get; set; }

    public Class(Teacher teacher, List<Student> students, string name, int id)
    {
        Teacher = teacher;
        Students = students;
        Name = name;
        Id = id;
    }
    
    public Class(Teacher teacher, List<Student> students, string name)
    {
        Teacher = teacher;
        Students = students;
        Name = name;
    }
    
    public Class(List<Student> students, string name)
    {
        Students = students;
        Name = name;
    }
}