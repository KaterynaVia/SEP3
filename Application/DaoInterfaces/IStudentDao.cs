using Domain;
using Domain.DTOs;

namespace Application.DaoInterfaces;

/*
 * This interface is used to define the methods that will be used to access the data of the Student entity.
 */

public interface IStudentDao
{
    Task<Student?> GetByIdAsync(string id);         // Returns a Student object with the given id.
    Task CreateAsyncStudent(Student student);
    public Task<IEnumerable<Student>> GetAsyncStudent(SearchUserParametersDto searchParameters);    // Returns a list of Student objects that match the given parameters.
}