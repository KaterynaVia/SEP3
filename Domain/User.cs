namespace Domain;

public class User
{
    
    public  int Id { get; set; }
    public string Password { get; set; }

    public User(string password, int id)
    {
        Id = id;
        Password = password;
    }
}