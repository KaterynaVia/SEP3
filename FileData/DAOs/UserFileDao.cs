using Application.DaoInterfaces;
using Domain;
using Domain.DTOs;

namespace FileData.DAOs;

/// <summary>
///  This class is used to access the data of the users in the database.
///  It implements the interfaces IStudentDao and ITeacherDao.
///  </summary>

public class UserFileDao : IStudentDao, ITeacherDao
{
    private readonly FileContext context;

    public UserFileDao(FileContext context)
    {
        this.context = context;
    }


    public Task<Student?> GetByIdAsync(string userName)
    {
        var existing = context.Students.FirstOrDefault(u =>
            u.Id.Equals(userName, StringComparison.OrdinalIgnoreCase)
        );
        return Task.FromResult(existing);
    }

    public Task CreateAsyncStudent(Student student)
    {
        var userId = 1;
        if (context.Students.Any())
        {
            userId = context.Students.Max(s => s.UserId);
            userId++;
        }

        student.UserId = userId;

        context.Students.Add(student);
        context.SaveChanges();
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Student>> GetAsyncStudent(SearchUserParametersDto searchParameters)
    {
        var students = context.Students.AsEnumerable();
        if (searchParameters.IdContains != null)
            students = context.Students.Where(u =>
                u.Id.Contains(searchParameters.IdContains, StringComparison.OrdinalIgnoreCase));

        return Task.FromResult(students);
    }

    public Task<Teacher> CreateAsyncTeacher(Teacher teacher)
    {
        /*
         * in case for some reason the id is not set
         * 1. Get the max id from the database
         * 2. Increment the id
         * 3. Set the id of the new teacher to the incremented id
         * 4. Add the teacher to the database
         * 5. Save the changes
         * 6. Return the teacher
         */
        var userId = 1;
        if (context.Teachers.Any())
        {
            userId = context.Teachers.Max(s => s.UserId);
            userId++;
        }

        teacher.UserId = userId;

        context.Teachers.Add(teacher);
        context.SaveChanges();

        return Task.FromResult(teacher);
    }

    public Task<Teacher?> GetByIdAsyncTeacher(string id)
    {
        var existing = context.Teachers.FirstOrDefault(u =>
            u.Id.Equals(id, StringComparison.OrdinalIgnoreCase)
        );
        return Task.FromResult(existing);
    }


    public Task<IEnumerable<Teacher>> GetAsyncTeacher(SearchUserParametersDto searchParameters)
    {
        var teachers = context.Teachers.AsEnumerable();
        if (searchParameters.IdContains != null)
            teachers = context.Teachers.Where(u =>
                u.Id.Contains(searchParameters.IdContains, StringComparison.OrdinalIgnoreCase));

        return Task.FromResult(teachers);
    }
}