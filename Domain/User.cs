using System.Text.Json.Serialization;

namespace Domain;

/*
 * Represents a user in the system
 * This class is used to represent a user in the system
 * It is used as a base class for the Student, Teacher and Supervisor classes
 */

public class User
{
    public User(string id, string password)
    {
        Id = id;
        Password = password;
    }

    public User()
    {
    }

    [JsonPropertyName("Id")] public string Id { get; set; }

    [JsonPropertyName("UserId")] public int UserId { get; set; }

    [JsonPropertyName("Password")] public string Password { get; set; }
}