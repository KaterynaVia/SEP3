using Domain;
using Domain.Models.DTOs;

namespace BlazorWasm.ILogic;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDto userToCreate);
    public Task<IEnumerable<User>> GetAsync(UserParametersDto searchParameters);
}