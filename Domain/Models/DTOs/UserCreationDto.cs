namespace Domain.Models.DTOs;

public class UserCreationDto
{
    public int Id { get;}
    public string Password { get; }

    public UserCreationDto(int id, string password)
    {
        Id = id;
        Password = password;
    }
}