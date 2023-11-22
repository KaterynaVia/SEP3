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
        HttpResponseMessage response = await client.PostAsJsonAsync("/classes", dto);

        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }
}