using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

/// <summary>
///    Interface for the StudentLogic class.
///  Defines the methods that the StudentLogic class must implement.
/// </summary>

public interface IStudentLogic
{
    Task<Student> CreateAsyncStudent(StudentCreationDto userToCreate);
    public Task<IEnumerable<Student>> GetAsyncStudent(SearchUserParametersDto searchParameters);
}