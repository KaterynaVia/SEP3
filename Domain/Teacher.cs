namespace Domain;

public class Teacher : User
{
    public string Name { get; set; }
    public Teacher(string name, string password, int id) : base(password, id)
    {
        Name = name;
    }
}