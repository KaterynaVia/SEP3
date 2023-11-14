using System.ComponentModel.DataAnnotations;
using BlazorWasm.ILogic;
using Domain;
using Domain.Models.DTOs;
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

    public async Task<User> GetUser(int id, string password)
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

        if (// user.Id == null ||
            user.Id == 0)
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