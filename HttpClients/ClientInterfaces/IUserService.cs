using Domain;
using Domain.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<Student> CreateStudent(UserCreationDto dto);
    Task<Teacher> CreateTeacher(UserCreationDto dto);
}