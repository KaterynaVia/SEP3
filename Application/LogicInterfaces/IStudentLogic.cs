using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IStudentLogic
{
    Task<Student> CreateAsyncStudent(UserCreationDto userToCreate);
    public Task<IEnumerable<Student>> GetAsyncStudent(SearchUserParametersDto searchParameters);
}