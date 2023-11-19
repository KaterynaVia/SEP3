using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IClassLogic
{
    Task<Class> CreateAsyncClass(ClassCreationDto dto);
}