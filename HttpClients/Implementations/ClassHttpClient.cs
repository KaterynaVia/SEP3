using System.Net.Http.Json;
using Domain.DTOs;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class ClassHttpClient : IClassService        // Implementation of the class service
{
    private readonly HttpClient client;

    public ClassHttpClient(HttpClient client)       // Constructor for the class client
    {
        this.client = client;
    }

    public async Task CreateAsyncClass(ClassCreationDto dto)        // Create a class, returns nothing if successful or throws an exception if unsuccessful
    {
        var response = await client.PostAsJsonAsync("/classes", dto);       // Post the class creation dto to the classes endpoint

        if (!response.IsSuccessStatusCode)      // If the response is not successful, throw an exception
        {
            var content = await response.Content.ReadAsStringAsync();       // Read the response content
            throw new Exception(content);       // Throw an exception with the response content
        }
    }
}