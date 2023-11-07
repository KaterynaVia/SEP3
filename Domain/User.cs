namespace Domain;

public class User
{
    public  string Id { get; set; }
    public int UserId { get; set; }
    public string Password { get; set; }
    

    public User(string id, string password)
    {
        Id = id;
        Password = password;
    }
    
}