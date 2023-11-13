namespace Domain;

public class User
{
    public int Id { get; set; }
    public string Password { get; set; }

   public User(int id ,string password)
   {
      Id = id;
      Password = password; 
   }
}