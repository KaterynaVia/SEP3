namespace Domain;

public class Class
{
    
    public string Name { get; set; }
    public Teacher Teacher { get; set; }
    public List<Student> Students = new List<Student>();

    Class(Teacher teacher, List<Student> students, string name)
    {
        Teacher = teacher;
        Students = students;
        Name = name;
    }


}