namespace Domain;

public class Supervisor : User
{
    public Supervisor(string password, string id, int userId) : base(id, password)
    {
    }
    
    public Supervisor(){}
}