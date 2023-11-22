namespace Domain;

/*
 * Represents a class of students and a teacher
 */

public class Class
{
    public List<Student> Students = new();              // List of students in the class

    public Class(Teacher teacher, List<Student> students, string name, int id)      // Constructor
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

    public string Name { get; set; }
    public Teacher Teacher { get; set; }
    public int Id { get; set; }
}