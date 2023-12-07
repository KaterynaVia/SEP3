using Domain;

namespace WebApi.Services;

public interface IAuthService
{
    Task<User> GetUser(string id, string password);
    Task<User> ValidateUser(string id, string password);
    Task<IEnumerable<string>> GetUserRoles(string id);
    Task RegisterUser(User user);
}