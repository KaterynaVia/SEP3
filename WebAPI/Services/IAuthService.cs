using Domain;

namespace WebApi.Services;

public interface IAuthService
{
    Task<User> GetUser(int id, string password);
    Task<User> ValidateUser(int id, string password);
    Task RegisterUser(User user);
}