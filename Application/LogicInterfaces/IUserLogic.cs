using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

/// <summary>
///  Interface for the UserLogic class.
///  Defines the methods that the UserLogic class must implement.
/// </summary>

public interface IUserLogic
{
    /*
     * Create a new user
     * Get all users
     */
    Task<User> CreateAsync(UserCreationDto userToCreate);
    public Task<IEnumerable<User>> GetAsync(UserParametersDto searchParameters);
}