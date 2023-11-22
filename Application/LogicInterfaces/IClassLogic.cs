using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

/// <summary>
///   Interface for the ClassLogic class.
///  Defines the methods that the ClassLogic class must implement.
/// </summary>

public interface IClassLogic
{
    Task<Class> CreateAsyncClass(ClassCreationDto dto);     // Create a new class
}