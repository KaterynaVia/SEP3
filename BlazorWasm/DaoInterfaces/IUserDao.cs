using Domain;
using Domain.Models.DTOs;

namespace BlazorWasm.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsernameAsync(int id);
    public Task<IEnumerable<User>> GetAsync(UserParametersDto searchParameters);
    Task<User?> GetByIdAsync(int id);
    Task DeleteAsync(int id);
}