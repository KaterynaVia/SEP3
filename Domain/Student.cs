namespace Domain;

public class Student : User
{
    public string Name { get; set; }
    public Student(string id, string password, string name) : base(id, password)
    {
        Name = name;
    }
    
}