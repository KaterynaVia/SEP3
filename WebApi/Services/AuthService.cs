using System.ComponentModel.DataAnnotations;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace WebApi.Services;

/*
 * This service is responsible for handling all authentication requests.
 * It uses the IAuthService interface to access the logic layer.
 * The service is responsible for handling the HTTP requests and responses.
 */

public class AuthService : IAuthService     // Implementation of the authentication service
{
    private readonly IUserLogic userLogic;

    private readonly IList<User> users = new List<User>     // A list of users for testing purposes 
    {
        new("112233", "password"),
        new("332211", "password1")
    };

    public AuthService(IUserLogic userLogic)        // The constructor for dependency injection of the logic layer interface
    {
        this.userLogic = userLogic;
    }

    public Task<User> ValidateUser(string id, string password)      // The method for validating a user by ID and password
    {
        var existingUser = users.FirstOrDefault(u => u.Id.Equals(id, StringComparison.OrdinalIgnoreCase));   // Find the user in the list of users
        if (existingUser == null) throw new Exception("User not found");        // If the user is not found, throw an exception

        if (!existingUser.Password.Equals(password)) throw new Exception("Password mismatch");      // If the password does not match, throw an exception

        return Task.FromResult(existingUser);       // Return the user
    }

    public async Task<User> GetUser(string id, string password)     // the method for getting a user by ID and password
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

    public Task RegisterUser(User user)     // The method for registering a user 
    {
        if (user.Id.Equals(null)) throw new ValidationException("ID cannot be null");   // Validate the user info

        if (string.IsNullOrEmpty(user.Password)) throw new ValidationException("Password cannot be null");  // Validate the user info
        // Do more user info validation here

        // save to persistence instead of list

        users.Add(user);        // Add the user to the list of users

        return Task.CompletedTask;      // Return a completed task
    }
}