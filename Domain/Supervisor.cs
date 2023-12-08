namespace Domain;

public class Supervisor : User
{
    public string UserType = "Supervisor";
    public Supervisor(string password, string id, int userId) : base(id, password)
    {
    }

    public Supervisor()
    {
    }
}