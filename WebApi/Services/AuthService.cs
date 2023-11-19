using System.ComponentModel.DataAnnotations;
using Application.Logic;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
namespace WebApi.Services;


public class AuthService : IAuthService
{
        private readonly IUserLogic userLogic;
    
        public AuthService(IUserLogic userLogic)
        {
            this.userLogic = userLogic;
        }

    private readonly IList<User> users = new List<User>
    {
        new User(id:"112233", password: "password"),
        new User(id:("332211"), password: "password1")
    };

    public Task<User> ValidateUser(string id, string password)
    {
        User? existingUser = users.FirstOrDefault(u => u.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
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

    public async Task<User> GetUser(string id, string password)
    {
        UserParametersDto parameters = new(id);
        Console.WriteLine("a");
        IEnumerable<User> users = await userLogic.GetAsync(parameters);
        Console.WriteLine("b");
        User? user = users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            return user;
        }
        else
        {
            throw new Exception("List of users empty.");
        }
    }

    public Task RegisterUser(User user)
    {

        if (user.Id.Equals(null))
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