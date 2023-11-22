using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

/// <summary>
///  Interface for the TeacherLogic class.
///  Defines the methods that the TeacherLogic class must implement.
/// </summary>

public interface ITeacherLogic
{
    /*
     * Create a new teacher
     * Get all teachers
     */
    Task<Teacher> CreateAsyncTeacher(TeacherCreationDto userToCreate);
    public Task<IEnumerable<Teacher>> GetAsyncTeacher(SearchUserParametersDto searchParameters);
}