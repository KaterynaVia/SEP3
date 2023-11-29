using System.Net.Http.Json;
using Domain.DTOs;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class ClassHttpClient : IClassService
{
    private readonly HttpClient client;

    public ClassHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task CreateAsyncClass(ClassCreationDto dto)
    {
        var response = await client.PostAsJsonAsync("/classes", dto);

        if (!response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }
}