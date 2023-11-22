using Domain;
using Domain.DTOs;

namespace Application.DaoInterfaces;

/**
 * Interface for the User DAO
 * Defines the methods that the User DAO must implement
 */

public interface IUserDao
{
    Task<User> CreateAsync(User user);          // Create a new user
    Task<User?> GetByUsernameAsync(string id);      // Get a user by username
    public Task<IEnumerable<User>> GetAsync(UserParametersDto searchParameters);        // Get all users
    Task<User?> GetByIdAsync(int id);           // Get a user by id
    Task DeleteAsync(int id);               // Delete a user
}