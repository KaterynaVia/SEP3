using Domain;
using Domain.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<Student> CreateStudent(StudentCreationDto dto);
    Task<Teacher> CreateTeacher(TeacherCreationDto dto);
}