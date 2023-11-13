using System.ComponentModel.DataAnnotations;
using BlazorWasm.Services;
using Domain;
using Shared.Models;

namespace WebApi.Services;

public class AuthService : IAuthService
{

    private readonly IList<User> users = new List<User>
    {
        new User(id: Convert.ToInt32("112233"), password: "password"),
        new User(id: Convert.ToInt32("332211"), password: "password1")
    };

    public Task<User> ValidateUser(int id, string password)
    {
        User? existingUser = users.FirstOrDefault(u => u.Id == id);
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return Task.FromResult(existingUser);
    }

    public Task RegisterUser(User user)
    {

        if (user.Id == null || user.Id == 0)
        {
            throw new ValidationException("ID cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }
        // Do more user info validation here
        
        // save to persistence instead of list
        
        users.Add(user);
        
        return Task.CompletedTask;
    }
}