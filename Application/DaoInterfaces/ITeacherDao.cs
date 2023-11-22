using Domain;
using Domain.DTOs;

namespace Application.DaoInterfaces;

/*
 * This interface is used to define the methods that will be used to access the data of the Teacher class.
 */

public interface ITeacherDao
{
    Task<Teacher> CreateAsyncTeacher(Teacher teacher);      // Create a new Teacher
    Task<Teacher?> GetByIdAsyncTeacher(string id);          // Get a Teacher by id
    public Task<IEnumerable<Teacher>> GetAsyncTeacher(SearchUserParametersDto searchParameters);        // Get all Teachers
}