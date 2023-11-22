using Domain.DTOs;

namespace HttpClients.ClientInterfaces;

/*
 * This file defines the interface for the class service.
 * The class service is responsible for creating classes.
 * The class service is used by the class controller.
 * The class service is implemented by the class client.
 */

public interface IClassService
{
    Task CreateAsyncClass(ClassCreationDto dto);        // Create a class
}