using System.ComponentModel.DataAnnotations;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace WebApi.Services;

public class AuthService : IAuthService
{
    private readonly IUserLogic userLogic;

    private readonly IList<User> users = new List<User>
    {
        new("112233", "password"),
        new("332211", "password1")
    };

    public AuthService(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }

    public Task<User> ValidateUser(string id, string password)
    {
        var existingUser = users.FirstOrDefault(u => u.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        if (existingUser == null) throw new Exception("User not found");

        if (!existingUser.Password.Equals(password)) throw new Exception("Password mismatch");

        return Task.FromResult(existingUser);
    }

    // This method would be used for the role separation to grant access to what each role should have access to
    public Task<IEnumerable<string>> GetUserRoles(string id)
    {
        // Retrieve the user from the list based on the provided Id
        var user = users.FirstOrDefault(u => u.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

        if (user == null)
        {
            throw new Exception("User not found");
        }

        // Logic to determine user roles based on the user Id
        var roles = new List<string>();

        // Assign role based on the user ID
        if (id.Equals(user.Id, StringComparison.OrdinalIgnoreCase))
        {
            roles.Add("Teacher");
        }
        else if (id.Equals(user.Id, StringComparison.OrdinalIgnoreCase))
        {
            roles.Add("Student");
        }
        else if (id.Equals(user.Id, StringComparison.OrdinalIgnoreCase))
        {
            roles.Add("Supervisor");
        }

        return Task.FromResult<IEnumerable<string>>(roles);
    }

    public async Task<User> GetUser(string id, string password)
    {
        UserParametersDto parameters = new(id);
        Console.WriteLine("a");
        var users = await userLogic.GetAsync(parameters);
        Console.WriteLine("b");
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user != null)
            return user;
        throw new Exception("List of users empty.");
    }

    public Task RegisterUser(User user)
    {
        if (user.Id.Equals(null)) throw new ValidationException("ID cannot be null");

        if (string.IsNullOrEmpty(user.Password)) throw new ValidationException("Password cannot be null");
        // Do more user info validation here

        // save to persistence instead of list

        users.Add(user);

        return Task.CompletedTask;
    }
}