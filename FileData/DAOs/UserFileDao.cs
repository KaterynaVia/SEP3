using Application.DaoInterfaces;
using Domain;
using Domain.DTOs;

namespace FileData.DAOs;

public class UserFileDao : IStudentDao, ITeacherDao
{
    private readonly FileContext context;

    public UserFileDao(FileContext context)
    {
        this.context = context;
    }


    public Task<Student?> GetByIdAsync(string userName)
    {
        Student? existing = context.Students.FirstOrDefault(u =>
            u.Id.Equals(userName, StringComparison.OrdinalIgnoreCase)
        );
        return Task.FromResult(existing);
    }

    public Task<Teacher> CreateAsyncTeacher(Teacher teacher)
    {
        int userId = 1;
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

    public Task CreateAsyncStudent(Student student)
    {
        int userId = 1;
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
        IEnumerable<Student> students = context.Students.AsEnumerable();
        if (searchParameters.IdContains != null)
        {
            students = context.Students.Where(u =>
                u.Id.Contains(searchParameters.IdContains, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(students);
    }

    public Task<Teacher?> GetByIdAsyncTeacher(string viaID)
    {
        Teacher? existing = context.Teachers.FirstOrDefault(u =>
            u.Id.Equals(viaID, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(existing);
    }

    public Task<IEnumerable<Teacher>> GetAsyncTeacher(SearchUserParametersDto searchParameters)
    {
        IEnumerable<Teacher> teachers = context.Teachers.AsEnumerable();
        if (searchParameters.IdContains != null)
        {
            teachers = context.Teachers.Where(u =>
                u.Id.Contains(searchParameters.IdContains, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(teachers);
    }
    
}