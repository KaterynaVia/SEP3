using Domain;

namespace WebApi.Services;

/*
 * This interface is responsible for defining the methods that the AuthService class must implement.
 */

public interface IAuthService
{
    Task<User> GetUser(string id, string password);
    Task<User> ValidateUser(string id, string password);
    Task RegisterUser(User user);
}