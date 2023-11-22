namespace Domain;

/*
 * Represents a supervisor user in the system
 */

public class Supervisor : User
{
    public Supervisor(string password, string id, int userId) : base(id, password)
    {
    }

    public Supervisor()
    {
    }
}