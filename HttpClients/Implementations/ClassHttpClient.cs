using System.Net.Http.Json;
using System.Text.Json;
using Domain;
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
    public async Task<IEnumerable<Class>> GetClass(string? name = null)
    {
        string uri = "/classes";
        if (!string.IsNullOrEmpty(name))
        {
            uri += $"?Name={name}";
        }
        HttpResponseMessage response = await client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        IEnumerable<Class> classes = JsonSerializer.Deserialize<IEnumerable<Class>>(result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return classes;
    }
}