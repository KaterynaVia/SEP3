using Domain;
using Domain.DTOs;

namespace HttpClients.ClientInterfaces;

/*
 * This file defines the interface for the user service.
 * The user service is responsible for creating users.
 * The user service is used by the user controller.
 * The user service is implemented by the user client.
 */

public interface IUserService       // Interface for the user service
{
    Task<Student> CreateStudent(UserCreationDto dto);       // Create a student
    Task<Teacher> CreateTeacher(UserCreationDto dto);       // Create a teacher
}