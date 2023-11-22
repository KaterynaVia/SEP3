using Domain.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IClassService
{
    Task CreateAsyncClass(ClassCreationDto dto);
}