using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface ITeacherLogic
{
    Task<Teacher> CreateAsyncTeacher(UserCreationDto userToCreate);
    public Task<IEnumerable<Teacher>> GetAsyncTeacher(SearchUserParametersDto searchParameters);

}